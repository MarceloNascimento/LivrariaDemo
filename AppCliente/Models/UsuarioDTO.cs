namespace DTO
{
   public class UsuarioDTO 
    {
        /// <summary>
        /// Código of usuário
        /// </summary>        
        public int Codigo { get; set; }

        /// <summary>
        /// Nome of usuário
        /// </summary> 
        public string Nome { get; set; }
        /// <summary>
        /// Nome of usuário
        /// </summary> 
        public string Login { get; set; }
      
        /// codigo do perfil daquele usuário no banco
        /// </summary> 
        public int PerfilId { get; set; }
       
        /// <summary>
        /// Descrição do perfil daquele usuário no banco
        /// </summary>
        public string PerfilNome { get; set; }

        /// <summary>
        /// codigo do perfil Cliente usuário no banco
        /// </summary> 
        public int ClienteId { get; set; }

        /// <summary>
        /// Descrição do Cliente daquele usuário no banco
        /// </summary>
        public string ClienteNome { get; set; }

    }
}
