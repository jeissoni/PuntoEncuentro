//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuntoEncuentro.Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_Evento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_Evento()
        {
            this.t_AsistenciaEvento = new HashSet<t_AsistenciaEvento>();
        }
    
        public int IdEvento { get; set; }
        public string NombreEvento { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.TimeSpan HoraIncio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public System.TimeSpan HoraFin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_AsistenciaEvento> t_AsistenciaEvento { get; set; }
    }
}