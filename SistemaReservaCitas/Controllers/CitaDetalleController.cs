using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaCitas.Models;
namespace SistemaReservaCitas.Controllers
{
    public class CitaDetalleController : Controller
    {
        DetalleCita objDetalleCita = new DetalleCita();
        //private Especialista objEspecialista = new Especialista();
        private HorarioAtencionDia objHoraioDia = new HorarioAtencionDia();
        private HorarioAtencionDetalle objHorarioDetalle = new HorarioAtencionDetalle();
        // GET: CitaDetalle
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Visualizar(int id)
        {
            return View(objDetalleCita.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Horas = objHorarioDetalle.Listar();
            return View(id == 0 ? new DetalleCita() // Agregarmos un nuevo objeto
                : objDetalleCita.Obtener(id) //Devuelve el id del objeto
                );
        }

        public ActionResult Guardar(DetalleCita objDetalleCita)
        {
            if (ModelState.IsValid)
            {
                objDetalleCita.Guardar();
                return Redirect("~/HorarioAtencionDia");
            }
            else
            {
                return View("~/Views/HorarioAtencionDia/AgregarEditar.cshtml", objDetalleCita);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objDetalleCita.horarioAtencionDia_id = id;
            objDetalleCita.Eliminar();
            return Redirect("~/HorarioAtencionDia");
        }
    }
}