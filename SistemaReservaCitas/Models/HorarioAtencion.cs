namespace SistemaReservaCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HorarioAtencion")]
    public partial class HorarioAtencion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HorarioAtencion()
        {
            HorarioAtencionDia = new HashSet<HorarioAtencionDia>();
        }

        [Key]
        public int horarioAtencion_id { get; set; }

        public int especialista_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencionDia> HorarioAtencionDia { get; set; }
    }
}
