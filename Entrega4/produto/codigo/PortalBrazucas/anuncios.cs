//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortalBrazucas
{
    using System;
    using System.Collections.Generic;
    
    public partial class anuncios
    {
        public int idanuncio { get; set; }
        public int idUsuario { get; set; }
        public string tituloAnuncio { get; set; }
        public string conteudoAnuncio { get; set; }
        public string url_imagem { get; set; }
        public bool anuncioPublicado { get; set; }
    
        public virtual usuarios usuarios { get; set; }
    }
}