using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class ServicioController : Controller
    {

        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();

        // GET: Servicio
        public ActionResult Index()
        {
            return View();
        }
       
        public JsonResult ObtenerServicios()
        {
            List<Servicio> servicios = new List<Servicio>();

            servicios = LN.ObtenerServicios();

            return Json(servicios, JsonRequestBehavior.AllowGet);
        }


      public JsonResult ServicioXId(int Id)
        {            
            Servicio InfoServicio = LN.ServicioXId(Id);

            return Json(InfoServicio, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertarServicios()
        {
            return View();
        }


    }
}