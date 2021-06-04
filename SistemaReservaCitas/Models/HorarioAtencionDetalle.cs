namespace SistemaReservaCitas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    [Table("HorarioAtencionDetalle")]
    public partial class HorarioAtencionDetalle
    {
        [Key]
        public int horarioAtencionDetalle_id { get; set; }

        public int? horarioAtencionDia_id { get; set; }

        [StringLength(250)]
        public string hora { get; set; }

        [StringLength(1)]
        public string disponibilidad { get; set; }

        public virtual HorarioAtencionDia HorarioAtencionDia { get; set; }


        //LISTAR

        public List<HorarioAtencionDetalle> Listar()
        {
            var objHorarioAtencionDetalle = new List<HorarioAtencionDetalle>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioAtencionDetalle = db.HorarioAtencionDetalle.ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioAtencionDetalle;

        }

        public List<HorarioAtencionDetalle> ListarHorasDisponibles()
        {
           string D = "D";
            var objHorarioAtencionDetalle = new List<HorarioAtencionDetalle>();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioAtencionDetalle = db.HorarioAtencionDetalle
                                                .ToList();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioAtencionDetalle;

        }

        //Obtener
        public HorarioAtencionDetalle Obtener(int id)
        {
            var objHorarioAtencionDetalle = new HorarioAtencionDetalle();
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    objHorarioAtencionDetalle = db.HorarioAtencionDetalle
                        .Where(x => x.horarioAtencionDetalle_id == id)
                        .SingleOrDefault();
                }


            }
            catch (Exception ex)
            {
                throw;
            }

            return objHorarioAtencionDetalle;

        }

       

        /* public List<HorarioAtencionDetalle> Buscar(string criterioBusqueda)
         {
             var objHorarioAtencionDetalle = new List<HorarioAtencionDetalle>();
             try
             {
                 //ORIGEN DE DATOS
                 using (var db = new ReservaCita())
                 {
                     //SENTENCIAS LINQ
                     objHorarioAtencionDetalle = db.HorarioAtencionDetalle.Include("HorarioAtencionDia")
                         .Where(
                         x => x.HorarioAtencionDia.dia.Equals(criterioBusqueda) &&
                         x.HorarioAtencionDia.horarioAtencionDia_id.Equals(x.horarioAtencionDia_id)
                         ).ToList();
                 }


             }
             catch (Exception ex)
             {
                 throw;
             }

             return objHorarioAtencionDetalle;

         }*/

        public void Guardar()
        {
            try
            {
                //ORIGEN DE DATOS
                using (var db = new ReservaCita())
                {
                    //SENTENCIAS LINQ
                    if (this.horarioAtencionDetalle_id > 0)
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
