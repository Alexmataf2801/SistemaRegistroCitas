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

            if (!usuario.CTemp)
            {

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
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        public JsonResult ObtenerRoles()
        {
            try
            {
                List<Roles> roles = new List<Roles>();
                roles = LN.ObtenerRoles();

                return Json(roles, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }

        public JsonResult ObtenerTodoLosRoles()
        {
            try
            {
                List<Roles> roles = new List<Roles>();

                usuario = (Usuario)Session["Usuario"];
                roles = LN.ObtenerTodoLosRoles(usuario.IdRol);

                return Json(roles, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult ActualizarRol()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {

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
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        [HttpGet]
        public ActionResult ListaRoles()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {

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
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        public JsonResult DesactivarActivarRol(int IdRol, bool Estado)
        {
            try
            {
                bool SeActualizoEstado = false;

                SeActualizoEstado = LN.DesactivarActivarRol(IdRol, Estado);

                return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }

           
        }

        public JsonResult ElimnarRol(int IdRol)
        {
            try
            {
                bool SeElimino = false;

                SeElimino = LN.EliminarRol(IdRol);

                return Json(SeElimino, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            


        }

        public JsonResult ObtenerRolXId(int IdRol)
        {
            try
            {
                Roles rol = new Roles();

                rol = LN.ObtenerRolXId(IdRol);

                return Json(rol, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult ActualizarRol(Roles rol)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];
                bool SeActualizo = false;
                rol.UsuarioUltimaModificacion = usuario.NombreCompleto;
                SeActualizo = LN.ActualizarRol(rol);

                return Json(SeActualizo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }
           

        }

    }
}