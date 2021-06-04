using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaReservaCitas.Models;
namespace SistemaReservaCitas.Controllers
{
    public class CitasController : Controller
    {
        private Cita objCita = new Cita();
        private Especialista objEspecialista = new Especialista();
        private HorarioAtencionDia objHoraioDia = new HorarioAtencionDia();
        private HorarioAtencionDetalle objHorarioDetalle = new HorarioAtencionDetalle();
        // GET: Citas


        public ActionResult Index()
        {

            return View(objEspecialista.Listar());
        }

        public ActionResult ElegirDia(int id)
        {

            return View(objHoraioDia.Listar());

        }

        public ActionResult ElegirHora(int id)
        {
            return View(objHorarioDetalle.Listar());

        }
    }
}