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
    
    public partial class jogos
    {
        public int idJogo { get; set; }
        public System.DateTime dataJogo { get; set; }
        public System.TimeSpan horarioJogo { get; set; }
        public int estadioJogo { get; set; }
        public int equipeAJogo { get; set; }
        public int equipeBJogo { get; set; }
    
        public virtual estadios estadios { get; set; }
        public virtual selecoes selecoes { get; set; }
        public virtual selecoes selecoes1 { get; set; }
    }
}