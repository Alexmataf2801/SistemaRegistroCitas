using Entidades;
using Entidades.ClasesEntidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        Utilidades utilidades = new Utilidades();
        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarEventos(Eventos eventos, string CorreoElectronicoCliente, string NombreColaborador)

        {
            Empresa empresa = new Empresa();
            int EmpresaUsuario = 0;
            int Respuesta = 0;
            int idCliente = 0;
            try
            {
                usuario = (Usuario)Session["Usuario"];
                eventos.UsuarioCreacion = usuario.NombreCompleto;
                eventos.IdUsuarioCrecion = usuario.Id;


                if (usuario.IdRol == 1)
                {
                    idCliente = LN.ValidarCorreoCliente(CorreoElectronicoCliente);

                    if (idCliente == 0)
                    {

                        eventos.IdUsuarioCrecion = usuario.Id;

                    }
                    else
                    {

                        eventos.IdUsuarioCrecion = idCliente;

                    }

                }
                EmpresaUsuario = Convert.ToInt32(usuario.IdEmpresa);

                empresa = LN.paObtenerEmpresasXId(EmpresaUsuario);

                TimeSpan HoraInicio = Convert.ToDateTime(eventos.HorarioInicial).TimeOfDay;
                //eventos.HorarioInicial.TimeOfDay;
                TimeSpan HoraFin = Convert.ToDateTime(eventos.HoraFinal).TimeOfDay;
                //TimeSpan HoraFin = eventos.HoraFinal.TimeOfDay;

                if (ValidarHoraEvento(eventos.IdDia, HoraInicio.ToString(), HoraFin.ToString()))
                {
                    Respuesta = LN.InsertarEventos(eventos, usuario.IdEmpresa, usuario.IdRol);

                    if (Respuesta == 1)
                    {
                        if (eventos.TipoUnidadEvento == 1)
                        {                       

                            String BODY = string.Format(@" 
                                <html>                                                      
                                </head>
 <body marginheight=""0"" topmargin=""0"" marginwidth=""0"" style=""margin: 0px; background-color: #f2f3f8;"" leftmargin=""0"">
   
    <table cellspacing=""0"" border=""0"" cellpadding=""0"" width=""100%"" bgcolor=""#f2f3f8"" style=""font-family: Open Sans,sans-serif;"">
        <tr>
            <td>
                <table style=""background-color: #f2f3f8; max-width:670px;  margin:0 auto;"" width=""100%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"">
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                   
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <table width=""95%"" border=""0"" align=""center"" cellpadding=""0"" cellspacing=""0"" style=""max-width:670px;background:#fff; border-radius:3px; text-align:center;-webkit-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);-moz-box-shadow:0 6px 18px 0 rgba(0,0,0,.06);box-shadow:0 6px 18px 0 rgba(0,0,0,.06);"">
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style=""padding:0px 35px;"">
                                        <h1 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family: Rubik,sans-serif;"">Información del Evento</h1>
                                        <span style=""display:inline-block; vertical-align:middle; margin:29px 0px 26px; border-bottom:1px solid #cecece; width:100px;""></span>
                                        <p style=""color:#455056;;text-align: justify; font-size:15px;line-height:24px; margin:0;"">
                                            Estimado/a Cliente <br><br>
                                            Usted ha recibido un comprobante de su cita de la empresa <strong>{0}</strong>
                                            para el día y fecha del <strong>{4}</strong> al <strong>{5}</strong> para el servicio <strong>{3}</strong>
                                            con nuestro colaborador <strong>{2}</strong>.<br><br>
                                            Esta cita fue solicitada por <strong>{1}</strong>.<br><br>
                                            Le esperamos pronto, gracias por preferir nuestros servicios.
                                        </p>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td style=""height:40px;"">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    <tr>
                        <td style=""height:20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style=""text-align:center;"">
                            <p style=""font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0px 0px 0px;"">Copyright &copy; {6} </p>
                        </td>
                    </tr>
                    <tr>
                        <td style=""height:80px;"">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
</body>
                                <body> 
                                ", empresa.Nombre, eventos.UsuarioCreacion, NombreColaborador, eventos.Nombre, eventos.HorarioInicial, eventos.HoraFinal, DateTime.Now.Year);
                            Correo correo = new Correo();
                            correo.Subject = "Información de Cita";
                            correo.Body = BODY;                             

                            if (idCliente == 0) // si es cero es porque no encontro ningun ID, osea la persona no estaba registrada en  el sistema
                            {
                                if (usuario.IdRol == 4)
                                {
                                    correo.To = usuario.CorreoElectronico;
                                }
                                else
                                {
                                    correo.To = CorreoElectronicoCliente;
                                    Respuesta = 7;
                                }
                            

                            }
                            else
                            {

                                correo.To = CorreoElectronicoCliente;

                            }


                            bool SeEnvioCorreo = utilidades.EnviarCorreoGenerico(correo);

                            if (!SeEnvioCorreo)
                            {
                                Respuesta = 6; // Si el valor es 6 quiere decir que se inserto el evento pero no se pudo enviar el correo
                            }

                        }

                    }

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