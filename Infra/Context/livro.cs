//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infra.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class livro
    {
        public int id { get; set; }
        public string isbn { get; set; }
        public string autor { get; set; }
        public string nome { get; set; }
        public string preco { get; set; }
        public Nullable<System.DateTime> dt_publicacao { get; set; }
        public string img_capa { get; set; }
    }
}