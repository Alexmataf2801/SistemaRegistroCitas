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

        public JsonResult ObtenerServiciosActivos()
        {
            try
            {
                List<Servicio> servicios = new List<Servicio>();


                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    servicios = LN.ObtenerServiciosActivos(usuario.IdEmpresa);

                }

                return Json(servicios, JsonRequestBehavior.AllowGet);
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


        public JsonResult ServicioXId(int Id)
        {
            try
            {
                Servicio InfoServicio = new Servicio();

                InfoServicio = LN.ServicioXId(Id);

                return Json(InfoServicio, JsonRequestBehavior.AllowGet);
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

        public JsonResult ObtenerTodosLosServicios()
        {
            try
            {
                List<Servicio> servicios = new List<Servicio>();
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    servicios = LN.ObtenerTodosLosServicios(usuario.IdEmpresa);
                }


                return Json(servicios, JsonRequestBehavior.AllowGet);
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

        public ActionResult InsertarServicios()
        {
            usuario =  (Usuario)Session["Usuario"];

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

        //[HttpPost]

        public JsonResult InsertarDatosServicios(Servicio servicio)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];
                servicio.UsuarioCreacion = usuario.NombreCompleto;
                bool Respuesta = LN.InsertarDatosServicios(servicio, usuario.IdEmpresa);

                return Json(Respuesta, JsonRequestBehavior.AllowGet);
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
        public ActionResult ListaServicios()
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

        public JsonResult DesactivarActivarServicios(int Id, bool Estado)
        {
            try
            {
                bool SeActualizoEstado = false;

                SeActualizoEstado = LN.DesactivarActivarServicios(Id, Estado);

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

        public JsonResult ElimnarServicio(int Id)
        {
            try
            {
                bool SeElimino = false;

                SeElimino = LN.EliminarServicios(Id);

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

        [HttpGet]
        public ActionResult ActualizarServicios()
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

        public JsonResult ActualizarServicios(Servicio servicio)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];
                bool SeActualizo = false;
                servicio.UsuarioUltimaModificacion = usuario.NombreCompleto;
                SeActualizo = LN.ActualizarServicios(servicio);

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