namespace SistemaReservaCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    [Table("DetalleCita")]
    public partial class DetalleCita
    {
        [Key]
        public int cita_id { get; set; }

        public int especialista_id { get; set; }

        public int usuario_id { get; set; }

        public int horarioAtencionDia_id { get; set; }

        public virtual Especialista Especialista { get; set; }

        public virtual HorarioAtencionDia HorarioAtencionDia { get; set; }

        public virtual Usuario Usuario { get; set; }


        public List<DetalleCita> Listar()
        {
            var objDetalleCita = new List<DetalleCita>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objDetalleCita = db.DetalleCita.ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objDetalleCita;

        }


        //Obtener
        public DetalleCita Obtener(int id)
        {
            var objDetalleCita = new DetalleCita();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objDetalleCita = db.DetalleCita
                        .Where(x => x.cita_id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objDetalleCita;

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
