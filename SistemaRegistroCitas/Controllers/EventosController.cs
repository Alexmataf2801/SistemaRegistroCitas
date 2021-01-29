using Entidades;
using Entidades.ClasesEntidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class EventosController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();

        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarEventos(Eventos eventos)

        {

            usuario = (Usuario)Session["Usuario"];

            int Respuesta = LN.InsertarEventos(eventos, usuario.IdEmpresa, usuario.IdRol);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }
    }
}