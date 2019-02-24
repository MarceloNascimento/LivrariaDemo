

namespace Infra.Repositories
{
    using AutoMapper;
    using DTO;
    using Infra.Context;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class LivroRepository : IRepository
    {

        /// <summary>
        /// Method constructor in here we mapped dto to entitie and reverse by automapper
        /// </summary>
        public LivroRepository()
        {

        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IDTO GetById(int codigo)
        {
            LivroDTO obj;
            using (var db = new modelEntities())
            {
                // Display all Blogs from the database 
                var query = from b in db.livroes where b.id == codigo select b;
                livro livro = query.FirstOrDefault();
                obj = Mapper.Map<livro, LivroDTO>(livro);
            }


            return obj;
        }

      

        /// <summary>
        /// to delete a user from database
        /// </summary>
        /// <param name="id">the id primary key from object</param>
        public void Delete(int codigo)
        {
            try
            {
                LivroDTO obj = new LivroDTO();
                using (var db = new modelEntities())
                {
                    // Display all Blogs from the database 
                    var query = from b in db.livroes where b.id == codigo select b;
                    livro livro = query.FirstOrDefault();
                    //Delete it from memory
                    db.livroes.Remove(livro);
                    //Save to database\ 
                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// to list all objects
        /// </summary>
        public IEnumerable<IDTO> ListAll()
        {
            IEnumerable<IDTO> AllObj = new List<LivroDTO>();
                using (var db = new modelEntities())
                {
                    // Display all livro from the database 
                    var query = from b in db.livroes select b;
                    List<livro> list = query.ToList();
                    AllObj = Mapper.Map<List<livro>, List<LivroDTO>>(list);

                }


                return AllObj;
            
        }

              

        /// <summary>
        /// to insert a new object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Save(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    livro Empresa = Mapper.Map<livro>(dto);

                    using (var db = new modelEntities())
                    {
                        using (var transaction = db.Database.BeginTransaction())
                        {
                                                 
                            db.livroes.Add(Empresa);
                            id = db.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// to update an object in db
        /// </summary>
        /// <param name="obj">a new object in db</param>
        public int Update(IDTO dto)
        {
            int id = 0;
            try
            {
                if (ValidateEntitie(dto))
                {
                    livro livro = Mapper.Map<livro>(dto);
                    using (var db = new modelEntities())
                    {                                           
                        db.Entry(livro).State = System.Data.Entity.EntityState.Modified;
                        id = db.SaveChanges();

                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// function to validate if this dto is according into business rules
        /// </summary>
        /// <param name="dto">a dto which will be validated</param>
        public bool ValidateEntitie(IDTO dto)
        {
            LivroDTO livrodto = (LivroDTO)dto;
            bool validated = false;
            if (string.IsNullOrEmpty(livrodto.ISBN) || string.IsNullOrWhiteSpace(livrodto.ISBN))
            {
                throw new Exception("O campo ISBN é obrigatório");
            }
            else
            {
                validated = true;
            }
            return validated;
        }

    }
}
