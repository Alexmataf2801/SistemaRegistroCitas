using Entidades;
using Entidades.ClasesEntidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class UsuarioController : Controller
    {
        private LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarUsuario(Usuario usuario)
        {
            int Resp = 0;
            LN.InsertarUsuario(usuario, ref Resp);

            return Json(Resp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Loguear(Login login)
        {
            Usuario usuario = LN.Validarlogin(login);
            Session["Usuario"] = usuario;
            return Json(usuario,JsonRequestBehavior.AllowGet);
        }

    }
}