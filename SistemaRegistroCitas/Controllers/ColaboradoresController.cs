using Entidades;
using Entidades.ClasesEntidades;
using System;
using LogicaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class ColaboradoresController : Controller
    {
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();

        // GET: Colaboradores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerColaboradoresActivos()
        {
            List<Colaboradores> colaboradores = new List<Colaboradores>();

            colaboradores = LN.ObtenerColaboradoresActivos();

            return Json(colaboradores, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertarColaboradores() {
            return View();
        }



    }
}