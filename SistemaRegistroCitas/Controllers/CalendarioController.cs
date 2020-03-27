using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class CalendarioController : Controller
    {
        // GET: Calendario
        public ActionResult Calendario()
        {
            return View();
        }

        public JsonResult Prueba()
        {
            return Json("",JsonRequestBehavior.AllowGet);
        }


    }
}