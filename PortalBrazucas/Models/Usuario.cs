using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalBrazucas.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string nome { get; set; }

    }
}