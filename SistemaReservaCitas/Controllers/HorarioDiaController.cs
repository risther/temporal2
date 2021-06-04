using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaCitas.Models;
namespace SistemaReservaCitas.Controllers
{
    public class HorarioDiaController : Controller
    {
        // GET: HorarioDia
        private HorarioAtencionDia objHorarioAtencionDia = new HorarioAtencionDia();
       private HorarioAtencionDetalle objHorarioDetalle = new HorarioAtencionDetalle();
        // GET: Semestre

        //Borrar esta vista aux login
        public ActionResult VistaAux()
        {
            return View();
        }
        public ActionResult Index()
        {
           
                return View(objHorarioAtencionDia.Listar());
          
        }

        public ActionResult EditarHoras(int id = 0)
        {
            ViewBag.Horas = objHorarioDetalle.Listar();

            return View(id == 0 ? new HorarioAtencionDetalle() // Agregarmos un nuevo objeto
                : objHorarioDetalle.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Visualizar(int id)
        {
            return View(objHorarioAtencionDia.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
           // ViewBag.Docente = objDocente.Listar();

            return View(id == 0 ? new HorarioAtencionDia() // Agregarmos un nuevo objeto
                : objHorarioAtencionDia.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(HorarioAtencionDia objHorarioAtencionDia)
        {
            if (ModelState.IsValid)
            {
                objHorarioAtencionDia.Guardar();
                return Redirect("~/HorarioAtencionDia");
            }
            else
            {
                return View("~/Views/HorarioAtencionDia/AgregarEditar.cshtml", objHorarioAtencionDia);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objHorarioAtencionDia.horarioAtencionDia_id = id;
            objHorarioAtencionDia.Eliminar();
            return Redirect("~/HorarioAtencionDia");
        }
    }
}