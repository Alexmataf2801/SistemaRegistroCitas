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
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();

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

        public JsonResult ObtenerTodosLosServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            servicios = LN.ObtenerTodosLosServicios();

            return Json(servicios, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public ActionResult InsertarServicios()
        {
            usuario = (Usuario)Session["Usuario"];
            Menu = usuarioControllador.ArmarMenu(usuario.Id);

            if (usuario != null)
            {
                if (usuario.Id > 0)
                {
                    ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                    ViewBag.Menu = Menu;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        //[HttpPost]

        public JsonResult InsertarDatosServicios(Servicio servicio)
        {
            usuario = (Usuario)Session["Usuario"];
            servicio.UsuarioCreacion = usuario.NombreCompleto;
            bool Respuesta = LN.InsertarDatosServicios(servicio,usuario.IdEmpresa);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaServicios()
        {
            usuario = (Usuario)Session["Usuario"];
            Menu = usuarioControllador.ArmarMenu(usuario.Id);//(String)Session["Menu"];

            if (usuario != null)
            {
                if (usuario.Id > 0)
                {
                    ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                    ViewBag.Menu = Menu;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public JsonResult DesactivarActivarServicios(int Id, bool Estado)
        {

            bool SeActualizoEstado = false;

            SeActualizoEstado = LN.DesactivarActivarServicios(Id, Estado);

            return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ElimnarServicio(int Id)
        {
            bool SeElimino = false;

            SeElimino = LN.EliminarServicios(Id);

            return Json(SeElimino, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult ActualizarServicios()
        {
            usuario = (Usuario)Session["Usuario"];
            Menu = usuarioControllador.ArmarMenu(usuario.Id);//(String)Session["Menu"];

            if (usuario != null)
            {
                if (usuario.Id > 0)
                {
                    ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                    ViewBag.Menu = Menu;

                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        public JsonResult ActualizarServicios(Servicio servicio)
        {
            usuario = (Usuario)Session["Usuario"];
            bool SeActualizo = false;
            servicio.UsuarioUltimaModificacion = usuario.NombreCompleto;
            SeActualizo = LN.ActualizarServicios(servicio);

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }
    }
}