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
            List<Roles> roles = new List<Roles>();
            try
            {
               
                roles = LN.ObtenerRoles();

               
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
                                
            }
            return Json(roles, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerTodoLosRoles()
        {
            List<Roles> roles = new List<Roles>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];
                roles = LN.ObtenerTodoLosRoles(usuario.IdRol);
                
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

            }
            return Json(roles, JsonRequestBehavior.AllowGet);

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
            bool SeActualizoEstado = false;
            try
            {
                
                SeActualizoEstado = LN.DesactivarActivarRol(IdRol, Estado);

                
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

            }

            return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);


        }

        public JsonResult ElimnarRol(int IdRol)
        {
            bool SeElimino = false;
            try
            {                

                SeElimino = LN.EliminarRol(IdRol);

                
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
                                
            }
            return Json(SeElimino, JsonRequestBehavior.AllowGet);



        }

        public JsonResult ObtenerRolXId(int IdRol)
        {
            Roles rol = new Roles();
            try
            {               

                rol = LN.ObtenerRolXId(IdRol);
                
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
               
            }
            return Json(rol, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ActualizarRol(Roles rol)
        {
            bool SeActualizo = false;
            try
            {
                usuario = (Usuario)Session["Usuario"];               
                rol.UsuarioUltimaModificacion = usuario.NombreCompleto;
                SeActualizo = LN.ActualizarRol(rol);
                                
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

            }
            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }

    }
}