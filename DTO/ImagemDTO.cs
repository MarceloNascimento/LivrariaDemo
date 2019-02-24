namespace DTO
{
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;

    public class ImagemDTO : IDTO
    {
        /// <summary>
        /// Código da Imagem da capa
        /// </summary>        
        public int Codigo { get; set; }
        /// <summary>
        /// Nome do Livro
        /// </summary> 
        public string Nome { get; set; }

        /// <summary>
        /// Caminho de salvamento da imagem da capa
        /// </summary>
        public string Path { get; set; }
        
    }
}
