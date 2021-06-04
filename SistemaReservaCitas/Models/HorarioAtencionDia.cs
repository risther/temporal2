namespace SistemaReservaCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    [Table("HorarioAtencionDia")]
    public partial class HorarioAtencionDia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HorarioAtencionDia()
        {
            DetalleCita = new HashSet<DetalleCita>();
            HorarioAtencionDetalle = new HashSet<HorarioAtencionDetalle>();
        }

        [Key]
        public int horarioAtencionDia_id { get; set; }

        public int? horarioAtencion_id { get; set; }

        [StringLength(250)]
        public string dia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCita> DetalleCita { get; set; }

        public virtual HorarioAtencion HorarioAtencion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HorarioAtencionDetalle> HorarioAtencionDetalle { get; set; }

        public List<HorarioAtencionDia> Listar()
        {
            var objHorarioDia = new List<HorarioAtencionDia>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioDia = db.HorarioAtencionDia.Include("HorarioAtencionDetalle").ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioDia;

        }


        //Obtener
        public HorarioAtencionDia Obtener(int id)
        {
            var objHorarioAtencionDia = new HorarioAtencionDia();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioAtencionDia = db.HorarioAtencionDia.Include("HorarioAtencion")
                        .Where(x => x.horarioAtencionDia_id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioAtencionDia;

        }

        public List<HorarioAtencionDia> Buscar(string criterioBusqueda)
        {
            var objHorarioAtencionDia = new List<HorarioAtencionDia>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioAtencionDia = db.HorarioAtencionDia
                        .Where(
                        x => x.dia.Equals(criterioBusqueda)
                        ).ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioAtencionDia;

        }

        public void Guardar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    if (this.horarioAtencionDia_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //ELIMINAR

        public void Eliminar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ

                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
