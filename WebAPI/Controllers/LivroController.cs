

namespace APIServices.Controllers
{

    using DTO;
    using Infra.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using System.Web.Http;


    [RoutePrefix("api/Livro")]
    public class LivroController : ApiController
    {

        private static LivroRepository _rep;


        [HttpGet]
        public IList<LivroDTO> Get()
        {
            _rep = new LivroRepository();
            IList<LivroDTO> Livros = (IList<LivroDTO>)_rep.ListAll();
            return Livros;
        }

        // GET: api/Livro/5    
        [HttpGet]
        public LivroDTO Get(int id)
        {
            _rep = new LivroRepository();
            LivroDTO Livro = (LivroDTO)_rep.GetById(id);
            return Livro;
        }

        [HttpPost]
        // POST: api/Livro       
        public HttpResponseMessage Post()
        {
            try
            {
#pragma warning disable CS0219 // The variable 'codigo' is assigned but its value is never used
                var codigo = 0;
#pragma warning restore CS0219 // The variable 'codigo' is assigned but its value is never used
                var httpRequest = HttpContext.Current.Request;
                LivroDTO dto = new LivroDTO();
                if (httpRequest.Form.Count < 1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {

                    _rep.Save(dto);

                    return Request.CreateResponse(HttpStatusCode.Created);
                }

            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw new Exception("Ocorreu um erro ao tentar salvar os dados, contacte o suporte do sistema.");
            }
        }


        [HttpPut]
        // PUT: api/Livro/5
        public HttpResponseMessage Put()
        {
            try
            {

                var httpRequest = HttpContext.Current.Request;


                LivroDTO dto = new LivroDTO();

                if (httpRequest.Form.Count < 1)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {

                    _rep.Update(dto);
                }

                return Request.CreateResponse(HttpStatusCode.Created);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                throw new Exception("Ocorreu um erro ao tentar salvar os dados, contacte o suporte do sistema.");
            }

        }




        [HttpDelete]
        // DELETE: api/Livro/5
        public HttpResponseMessage Delete(int id)
        {
            _rep = new LivroRepository();
            try
            {
                _rep.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
