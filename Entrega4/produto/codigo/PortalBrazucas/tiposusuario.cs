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
    
    public partial class tiposusuario
    {
        public tiposusuario()
        {
            this.usuarios = new HashSet<usuarios>();
        }
    
        public int idtipoUsuario { get; set; }
        public string descricaoTipoUsuario { get; set; }
    
        public virtual ICollection<usuarios> usuarios { get; set; }
    }
}
