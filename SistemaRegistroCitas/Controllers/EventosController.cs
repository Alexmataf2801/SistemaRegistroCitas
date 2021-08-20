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
<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""table-layout:fixed;background-color:#f9f9f9"" id=""bodyTable"">
	<tbody>
		<tr>
			<td style=""padding-right:10px;padding-left:10px;"" align=""center"" valign=""top"" id=""bodyCell"">
				
				<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" class=""wrapperBody"" style=""max-width:600px"">
					<tbody>
						<tr>
							<td align=""center"" valign=""top"">
								<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" class=""tableCard"" style =""background-color:#fff;border-color:#e5e5e5;border-style:solid;border-width:0 1px 1px 1px;"">
									<tbody>

                                        <tr>
                                            <td style = ""background-color:#3c8dbc;font-size:1px;line-height:3px"" class=""topBorder"" height=""3"">&nbsp;</td>
										</tr>

                                        <tr>

                                            <td style = ""padding - bottom: 20px; "" align = ""center"" valign = ""top"" class=""imgHero"">
												<a style = ""text-decoration:none"" target=""_blank"">
													<img border = ""0"" src=""http://email.aumfusion.com/vespro/img/hero-img/blue/heroGradient/user-account.png"" style=""width:100%;max-width:600px;height:auto;display:block;color: #f9f9f9;"" width=""600"">
												</a>
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px; padding-bottom: 20px;"" align=""center"">																							
												<h1 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:400px;height:auto;display:block"" width=""150"">Informacion del evento</h1>												
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Nombre de la Empresa</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{0}</h3>											
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Creador del evento</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{1}</h3>											
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Nombre del Colaborador</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{2}</h3>											
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Nombre del Servicio</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{3}</h3>											
											</td>
										</tr>
										
										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Fecha Inicial de la Cita</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{4}</h3>											
											</td>
										</tr>

										<tr>
											<td style = ""padding-top: 30px;"" align=""center"">																							
												<h2 style = ""text-align:center; color:#FFFFFF; background-color: #3c8dbc; border-radius: 15px; width:100%;max-width:300px;height:auto;display:block"" width=""150"">Fecha Final de la Cita</h2>	
												<h3 style = ""text-align:center; color:#000000; font-size: 25px;"">{5}</h3>											
											</td>
										</tr>										
										
										<tr>
											<td style = ""padding-left:20px;padding-right:20px"" align=""center"" valign=""top"" class=""containtTable ui-sortable"">
												<table border = ""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" class=""tableDescription"">
													<tbody>
														<tr>
															<td style = ""padding-bottom: 20px;padding-top: 20px"" align=""center"" valign=""top"" class=""description"">
																<p class=""text"" style=""color:#666;font-family:'Open Sans',Helvetica,Arial,sans-serif;font-size:14px;font-weight:400;font-style:normal;letter-spacing:normal;line-height:22px;text-transform:none;text-align:center;padding:0;margin:0"">Gracias por agendar una cita con nosotros.Esperamos verte pronto en {0}.</p>
															</td>
														</tr>
													</tbody>
												</table>												
											</td>
										</tr>

										<tr>
											<td style = ""padding-bottom: 30px; padding-top: 30px; padding-left: 20px; padding-right: 20px;"" align=""center"" valign=""top"" class=""subTitle"">
												<h4 class=""text"" style=""color:#999;font-family:Poppins,Helvetica,Arial,sans-serif;font-size:16px;font-weight:500;font-style:normal;letter-spacing:normal;line-height:24px;text-transform:none;text-align:center;padding:0;margin:0"">Copyright &copy {6}</h4>
											</td>
										</tr>

										<tr>
											<td style = ""font-size:1px;line-height:1px"" height=""20"">&nbsp;</td>
										</tr>
										
									</tbody>
									<tr>
										<td style = ""background-color:#3c8dbc;font-size:1px;line-height:3px"" class=""topBorder"" height=""3"">&nbsp;</td>
									</tr>
								</table>
								<table border = ""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" class=""space"">
									<tbody>
										<tr>
											<td style = ""font-size:1px;line-height:1px"" height=""30"">&nbsp;</td>
										</tr>
									</tbody>
								</table>
							</td>
						</tr>
					</tbody>
				</table>
				
			</td>
		</tr>
	</tbody>
</table>      
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