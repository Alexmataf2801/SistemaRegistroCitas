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
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();

        // GET: Roles
        public ActionResult InsertarRoles()
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

        public JsonResult ObtenerRoles()
        {
            List<Roles> roles = new List<Roles>();
            roles = LN.ObtenerRoles();

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodoLosRoles()
        {
            List<Roles> roles = new List<Roles>();

            usuario = (Usuario)Session["Usuario"];
            roles = LN.ObtenerTodoLosRoles(usuario.IdRol);

            return Json(roles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ActualizarRol()
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

        [HttpGet]
        public ActionResult ListaRoles()
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

        public JsonResult DesactivarActivarRol(int IdRol, bool Estado)
        {

            bool SeActualizoEstado = false;

            SeActualizoEstado = LN.DesactivarActivarRol(IdRol, Estado);

            return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ElimnarRol(int IdRol)
        {
            bool SeElimino = false;

            SeElimino = LN.EliminarRol(IdRol);

            return Json(SeElimino, JsonRequestBehavior.AllowGet);


        }

        public JsonResult ObtenerRolXId(int IdRol)
        {
            Roles rol = new Roles();

            rol = LN.ObtenerRolXId(IdRol);

            return Json(rol, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActualizarRol(Roles rol)
        {
            usuario = (Usuario)Session["Usuario"];
            bool SeActualizo = false;
            rol.UsuarioUltimaModificacion = usuario.NombreCompleto;
            SeActualizo = LN.ActualizarRol(rol);

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }

    }
}