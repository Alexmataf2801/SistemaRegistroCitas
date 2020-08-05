using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class UnidadMedidaController : Controller
    {

        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        

        // GET: UnidadMedida
        public ActionResult InsertarUnidadMedida()
        {
            return View();
        }

        public JsonResult ObtenerMinutosYHoras()
        {
            List<UnidadMedida> unidadMedida = new List<UnidadMedida>();
            unidadMedida = LN.ObtenerMinutosYHoras();

            return Json(unidadMedida, JsonRequestBehavior.AllowGet);
        }
    }
}