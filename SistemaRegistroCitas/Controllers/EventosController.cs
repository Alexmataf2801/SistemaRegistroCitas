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
        EmpresaController empresaController = new EmpresaController();

        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarEventos(Eventos eventos)

        {
            int Respuesta = 0;

            try
            {
                usuario = (Usuario)Session["Usuario"];
                eventos.UsuarioCreacion = usuario.NombreCompleto;
                eventos.IdUsuarioCrecion = usuario.Id;
                

                TimeSpan HoraInicio = eventos.HorarioInicial.TimeOfDay;
                TimeSpan HoraFin = eventos.HoraFinal.TimeOfDay;

                if (ValidarHoraEvento(eventos.IdDia, HoraInicio.ToString(), HoraFin.ToString()))
                {
                    Respuesta = LN.InsertarEventos(eventos, usuario.IdEmpresa, usuario.IdRol);
                }
                else
                {
                    Respuesta = 5;
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
            return Json(Respuesta, JsonRequestBehavior.AllowGet);

        }

        public bool ValidarHoraEvento(int Dia, string Inicio, string Final)
        {
            bool Respuesta = false;

            try
            {
                HorarioEmpresa horarioEmpresa = new HorarioEmpresa();
                horarioEmpresa = (HorarioEmpresa)Session["HorarioEmpresa"];

                switch (Dia)
                {

                    case 0:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {

                            if (horarioEmpresa.InicioDomingo <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalDomingo >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }

                        }

                        break;
                    case 1:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {


                            if (horarioEmpresa.InicioLunes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalLunes >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }

                        break;
                    case 2:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {
                            if (horarioEmpresa.InicioMartes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalMartes >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }
                        break;
                    case 3:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {
                            if (horarioEmpresa.InicioMiercoles <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalMiercoles >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }

                        break;
                    case 4:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {
                            if (horarioEmpresa.InicioJueves <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalJueves >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }

                        break;
                    case 5:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {
                            if (horarioEmpresa.InicioViernes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalViernes >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }

                        break;
                    case 6:
                        if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                        {
                            if (horarioEmpresa.InicioSabado <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalSabado >= TimeSpan.Parse(Final))
                            {
                                Respuesta = true;
                            }
                        }

                        break;
                    default:
                        break;
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
           

           

            return Respuesta;

        }


        public JsonResult ObtenerTodosLosEventosXIdEmpresa()
        {
            List<Eventos> Eventos = new List<Eventos>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    Eventos = LN.ObtenerTodosLosEventosXIdEmpresa(usuario.IdEmpresa);
                }
               
            }
            catch (Exception ex )
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

            }
            return Json(Eventos, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ListaEvento()
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

        public JsonResult EliminarEventos(int Id)
        {
            bool SeElimino = false;
            try
            {               

                SeElimino = LN.EliminarEventos(Id);

                
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

        public JsonResult ObtenerTodosLosEventosXIdUsuarioCreador()
        {
            List<Eventos> Eventos = new List<Eventos>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    Eventos = LN.ObtenerTodosLosEventosXIdUsuarioCreador(usuario.Id, usuario.IdEmpresa);
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

            return Json(Eventos, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ListaEventoUsuarioCreador()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 4)
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

        public JsonResult ObtenerTodosLosEventosHorasLibresXIdEmpresa()
        {
            List<Eventos> Eventos = new List<Eventos>();
            try
            {
               
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    Eventos = LN.ObtenerTodosLosEventosHorasLibresXIdEmpresa(usuario.IdEmpresa);
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
            return Json(Eventos, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ListaEventoHorasLibres()
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

        public JsonResult ObtenerTodosLosEventosXIdUsuario()
        {
            List<Eventos> Eventos = new List<Eventos>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    Eventos = LN.ObtenerTodosLosEventosXIdUsuario(usuario.Id);
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

            return Json(Eventos, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult ListaEventoUsuario()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 3)
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



        public JsonResult ObtenerTodosLosEventosXIdUsuarioSeleccionado(int IdUsuario)
        {
            List<Eventos> Eventos = new List<Eventos>();
            try
            {
                
                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    Eventos = LN.ObtenerTodosLosEventosXIdUsuario(IdUsuario);
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
            return Json(Eventos, JsonRequestBehavior.AllowGet);

        }

    }
}