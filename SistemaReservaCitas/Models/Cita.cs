namespace SistemaReservaCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    [Table("Cita")]
    public partial class Cita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cita()
        {
            HistorialDoctor = new HashSet<HistorialDoctor>();
            HistorialUsuario = new HashSet<HistorialUsuario>();
        }

        [Key]
        public int cita_id { get; set; }

        [Required]
        [StringLength(250)]
        public string estadoAtencion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialDoctor> HistorialDoctor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialUsuario> HistorialUsuario { get; set; }

        //LISTAR

        public List<Cita> Listar()
        {
            var objCita = new List<Cita>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objCita = db.Cita.ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objCita;

        }


        //Obtener
        public Cita Obtener(int id)
        {
            var objCita = new Cita();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objCita = db.Cita
                        .Where(x => x.cita_id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objCita;

        }

       /* public List<Cita> Buscar(string criterioBusqueda)
        {
            var objCita = new List<Cita>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objCita = db.Cita
                        .Where(
                        x => x.cita_id.Contains(criterioBusqueda)).;
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objCita;

        }*/

        public void Guardar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    if (this.cita_id > 0)
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
