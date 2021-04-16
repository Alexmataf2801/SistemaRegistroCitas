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
            List<Servicio> servicios = new List<Servicio>();
            try
            {
                


                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    servicios = LN.ObtenerServiciosActivos(usuario.IdEmpresa);

                }

               
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
            return Json(servicios, JsonRequestBehavior.AllowGet);

        }


        public JsonResult ServicioXId(int Id)
        {
            Servicio InfoServicio = new Servicio();
            try
            {
               

                InfoServicio = LN.ServicioXId(Id);

                
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
            return Json(InfoServicio, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ObtenerTodosLosServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    servicios = LN.ObtenerTodosLosServicios(usuario.IdEmpresa);
                }


                
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

            return Json(servicios, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]

        public ActionResult InsertarServicios()
        {
            usuario =  (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)               
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
                   return RedirectToAction("InicioEmpresas", "InicioEmpresas");
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
            bool Respuesta = false;
            try
            {
                usuario = (Usuario)Session["Usuario"];
                servicio.UsuarioCreacion = usuario.NombreCompleto;
                 Respuesta = LN.InsertarDatosServicios(servicio, usuario.IdEmpresa);

                
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
            return Json(Respuesta, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ListaServicios()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
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
                    return RedirectToAction("InicioEmpresas", "InicioEmpresas");
                }
            }
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        public JsonResult DesactivarActivarServicios(int Id, bool Estado)
        {
            bool SeActualizoEstado = false;
            try
            {
                

                SeActualizoEstado = LN.DesactivarActivarServicios(Id, Estado);

                
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

        public JsonResult ElimnarServicio(int Id)
        {
            bool SeElimino = false;
            try
            {
                

                SeElimino = LN.EliminarServicios(Id);

               
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

        [HttpGet]
        public ActionResult ActualizarServicios()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
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
                    return RedirectToAction("InicioEmpresas", "InicioEmpresas");
                }
            }
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        public JsonResult ActualizarServicios(Servicio servicio)
        {
            bool SeActualizo = false;
            try
            {
                usuario = (Usuario)Session["Usuario"];                
                servicio.UsuarioUltimaModificacion = usuario.NombreCompleto;
                SeActualizo = LN.ActualizarServicios(servicio);

               
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