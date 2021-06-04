using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaCitas.Models;
namespace SistemaReservaCitas.Controllers
{
    public class HorarioDiaDetalleController : Controller
    {
        // GET: HorarioDia
      
        private HorarioAtencionDetalle objHorarioDetalle = new HorarioAtencionDetalle();
        // GET: Semestre

       
        public ActionResult Index(int id)
        {
                
                return View(objHorarioDetalle.Listar());
            
        }

        public ActionResult ElegirHoraCita(int id)
        {

            ViewBag.Horas = objHorarioDetalle.ListarHorasDisponibles();

            return View(id == 0 ? new HorarioAtencionDetalle() // Agregarmos un nuevo objeto
                : objHorarioDetalle.Obtener(id) //Devuelve el id del objeto
                );

        }

        public ActionResult AgregarEditar(int id)
        {
            ViewBag.Horas = objHorarioDetalle.Listar();

            return View(id == 0 ? new HorarioAtencionDetalle() // Agregarmos un nuevo objeto
                : objHorarioDetalle.Obtener(id) //Devuelve el id del objeto
                );
        }



        public ActionResult Guardar(HorarioAtencionDetalle objHorarioDetalle)
        {
            if (ModelState.IsValid)
            {
                objHorarioDetalle.Guardar();
                return Redirect("~/HorarioDia");
            }
            else
            {
                return View("~/Views/HorarioDiaDetalle/Index.cshtml", objHorarioDetalle);
            }
        }

      

        public ActionResult Eliminar(int id)
        {
            objHorarioDetalle.horarioAtencionDia_id = id;
            objHorarioDetalle.Eliminar();
            return Redirect("~/HorarioDiaDetalle");
        }
    }
}