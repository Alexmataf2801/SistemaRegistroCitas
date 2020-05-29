using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class RolesController : Controller
    {
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        // GET: Roles
        public ActionResult InsertarRoles()
        {
            return View();
        }

        public JsonResult ObtenerRoles()
        {
            List<Roles> roles = new  List<Roles>();
            roles = LN.ObtenerRoles();

            return Json(roles, JsonRequestBehavior.AllowGet);
        }
    }
}