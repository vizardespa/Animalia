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
    
    public partial class Invertebrados
    {
        public int IdInvertebrados { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }
        public Nullable<int> NumeroPatas { get; set; }
        public Nullable<int> IdHabitat { get; set; }
        public Nullable<int> IdTipoReproduccion { get; set; }
        public Nullable<int> IdTipoAlimentacion { get; set; }
        public Nullable<int> IdTipoRespiracion { get; set; }
        public Nullable<int> IdTipoSimetria { get; set; }
        public Nullable<int> IdTipoTejido { get; set; }
    
        public virtual Habitat Habitat { get; set; }
        public virtual TipoReproduccion TipoReproduccion { get; set; }
        public virtual TipoAlimentacion TipoAlimentacion { get; set; }
        public virtual TipoRespiracion TipoRespiracion { get; set; }
        public virtual TipoSimetria TipoSimetria { get; set; }
        public virtual TipoTejido TipoTejido { get; set; }
    }
}
