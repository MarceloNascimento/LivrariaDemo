

namespace DTO
{
    using System;
    using System.Collections.Generic;

    public class LivroDTO : IDTO
    {
        /// <summary>
        /// Código do Livro
        /// </summary>        
        public int Codigo { get; set; }
        /// <summary>
        ///  ISBN do Livro
        /// </summary> 
        public string ISBN { get; set; }
        /// <summary>
        ///  Nome do autor do Livro
        /// </summary> 
        public string Autor { get; set; }
        /// <summary>
        ///  CNPJ from Company
        /// </summary> 
        public string Preco { get; set; }

        /// <summary>
        /// Data da publicação do livro
        /// </summary>
        public DateTime DataPublicacao { get; set; }

        /// <summary>
        /// Caminho (Path) da imagem da capa 
        /// </summary>
        public string CaminhoImg { get; set; }
        /// <summary>
        /// Nome do Livro
        /// </summary>
        public string Nome { get; set; }
    }
}
