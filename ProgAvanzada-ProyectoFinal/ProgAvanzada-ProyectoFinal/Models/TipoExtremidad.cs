//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProgAvanzada_ProyectoFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoExtremidad
    {
        public TipoExtremidad()
        {
            this.Vertebrados = new HashSet<Vertebrados>();
        }
    
        public int IdTipoExtremidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ICollection<Vertebrados> Vertebrados { get; set; }
    }
}
