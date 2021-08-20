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
    public class UsuarioController : Controller
    {

        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        Utilidades utilidades = new Utilidades();



        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarUsuario(Usuario usuario)
        {
            int Resp = 0;

            try
            {

                usuario.TerminosYCondiciones = true;

                LN.InsertarUsuario(usuario, ref Resp);


            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;


                LN.InsertarBitacora(bitacora);



            }

            return Json(Resp, JsonRequestBehavior.AllowGet);


        }

        public JsonResult Loguear(Login login, int IdEmpresa)
        {
            try
            {
                Usuario usuario = LN.Validarlogin(login, IdEmpresa);
                usuario.IdEmpresa = IdEmpresa;
                Session["Usuario"] = usuario;
                ArmarMenu(usuario.Id);
                return Json(usuario, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);

            }
        }

        public JsonResult ObtenerUsuarioSesion()
        {

            Usuario usuarioSession = new Usuario();

            try
            {

                if (Session["Usuario"] != null)
                {

                    usuarioSession = (Usuario)Session["Usuario"];
                }


            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);

            }

            return Json(usuarioSession, JsonRequestBehavior.AllowGet);
        }



        public List<Menu> ObtenerMenuUsuario(int IdUsuario)
        {

            List<Menu> ListaMenu = new List<Menu>();

            try
            {
                ListaMenu = LN.ObtenerMenuUsuario(IdUsuario);
            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);


            }


            return ListaMenu;
        }


        public string ArmarMenu(int IdUsuario)
        {
            StringBuilder menuArmado = new StringBuilder();

            try
            {
                List<Menu> menu = ObtenerMenuUsuario(IdUsuario);



                menuArmado.Append("<ul class='sidebar-menu' data-widget='tree'>");
                menuArmado.Append("<li class='header'>MENU DE NAVEGACIÓN</li>");

                var listaPadres = menu.Where(p => p.IsPadre == "0").ToList();

                for (int j = 0; j < listaPadres.Count; j++)
                {
                    menuArmado.Append("<li class='treeview'>");
                    menuArmado.Append("<a href='" + listaPadres[j].Url + "'>");
                    menuArmado.Append("<i class='" + listaPadres[j].Icono + "'></i><span>" + listaPadres[j].Nombre + "</span>");
                    menuArmado.Append("<span class='pull-right-container'>");
                    menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                    menuArmado.Append("</span>");
                    menuArmado.Append("</a>");

                    var SegundoNivel = menu.Where(p => p.IdPadre == listaPadres[j].IdMenu).ToList();

                    if (SegundoNivel.Count > 0)
                    {
                        menuArmado.Append("<ul class='treeview-menu'>");
                    }

                    for (int k = 0; k < SegundoNivel.Count; k++)
                    {



                        var TercerNivel = menu.Where(p => p.IdPadre == SegundoNivel[k].IdMenu).ToList();

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("<li class='treeview'>");
                            menuArmado.Append("<a href='" + SegundoNivel[k].Url + "'>");
                            menuArmado.Append("<i class='" + SegundoNivel[k].Icono + "'></i><span>" + SegundoNivel[k].Nombre + "</span>");
                        }
                        else
                        {

                            menuArmado.Append("<li>");
                            menuArmado.Append("<a href='" + SegundoNivel[k].Url + "'>");
                            menuArmado.Append("<i class='" + SegundoNivel[k].Icono + "'></i><span>" + SegundoNivel[k].Nombre + "</span>");
                        }

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                            menuArmado.Append("</a>");
                            menuArmado.Append("<ul class='treeview-menu'>");
                        }

                        for (int a = 0; a < TercerNivel.Count; a++)
                        {
                            var CuartoNivel = menu.Where(p => p.IdPadre == TercerNivel[a].IdMenu).ToList();

                            if (CuartoNivel.Count > 0)
                            {
                                menuArmado.Append("<li class='treeview'>");
                                menuArmado.Append("<a href='" + TercerNivel[a].Url + "'>");
                                menuArmado.Append("<i class='" + TercerNivel[a].Icono + "'></i><span>" + TercerNivel[a].Nombre + "</span>");
                                menuArmado.Append("<span class='pull-right-container'>");
                                menuArmado.Append("<i class='fa fa-angle-left pull-right'></i>");
                                menuArmado.Append("</span>");
                                menuArmado.Append("</a>");
                                menuArmado.Append("<ul class='treeview-menu'>");

                                for (int i = 0; i < CuartoNivel.Count; i++)
                                {
                                    menuArmado.Append("<li>");
                                    menuArmado.Append("<a href='" + CuartoNivel[i].Url + "'><i class='" + CuartoNivel[i].Icono + "'>");
                                    menuArmado.Append("</i>" + CuartoNivel[i].Nombre + "</a>");

                                }

                                menuArmado.Append("</ul></li>");
                            }
                            else
                            {
                                menuArmado.Append("<li><a href='" + TercerNivel[a].Url + "'><i class='" + TercerNivel[a].Icono + "'></i>" + TercerNivel[a].Nombre);
                                menuArmado.Append("</a>");
                            }

                        }

                        if (TercerNivel.Count > 0)
                        {
                            menuArmado.Append("</ul></li>");
                        }
                        else
                        {
                            menuArmado.Append("</a>");
                            menuArmado.Append("</li>");
                        }

                    }
                    menuArmado.Append("</ul></li>");

                }
                menuArmado.Append("</ul>");
            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);
            }



            return menuArmado.ToString();
        }


        [HttpGet]
        public ActionResult InsertarColaborador()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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


        public JsonResult InsertarDatosColaborador(Usuario usuario)
        {
            int Resp = 0;
            try
            {

                Usuario usu = (Usuario)Session["Usuario"];
                usuario.IdEmpresa = usu.IdEmpresa;
                usuario.IdPlan = usu.IdPlan;
                LN.InsertarDatosColaborador(usuario, ref Resp);


            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;


                LN.InsertarBitacora(bitacora);
            }

            return Json(Resp, JsonRequestBehavior.AllowGet);

        }


        public JsonResult ObtenerColaboradoresActivos()
        {

            try
            {

                List<Usuario> usuarios = new List<Usuario>();

                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {

                    usuarios = LN.ObtenerColaboradoresActivos(usuario.IdEmpresa);

                }

                return Json(usuarios, JsonRequestBehavior.AllowGet);
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

        public JsonResult ObtenerTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = LN.ObtenerTodosUsuarios();

            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaColaboradores()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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


        public JsonResult ObtenerTodosLosColaboradores()
        {

            try
            {
                List<Usuario> usuarios = new List<Usuario>();

                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {
                    usuarios = LN.ObtenerTodosLosColaboradores(usuario.IdEmpresa, usuario.IdRol);

                }


                return Json(usuarios, JsonRequestBehavior.AllowGet);
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

        public JsonResult DesactivarActivarColaboradores(int Id, bool Estado)
        {
            try
            {

                bool SeActualizoEstado = false;

                SeActualizoEstado = LN.DesactivarActivarColaboradores(Id, Estado);

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

        public JsonResult EliminarColaboradores(int Id)
        {
            try
            {
                bool SeElimino = false;

                SeElimino = LN.EliminarColaboradores(Id);

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
        public ActionResult ActualizarColaboradores()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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

        public JsonResult ActualizarColaboradores(Usuario usuarios)
        {
            
            int SeActualizo = 0;
            try
            {
                usuario = (Usuario)Session["Usuario"];

                usuarios.UsuarioUltimaModificacion = usuario.NombreCompleto;
                usuarios.IdPlan = usuario.IdPlan;
                usuarios.IdEmpresa = usuario.IdEmpresa;
                SeActualizo = LN.ActualizarColaboradores(usuarios);
              
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


        public JsonResult ObtenerColaboradoresXId(int Id)
        {

            try
            {
                Usuario usuario = new Usuario();

                usuario = LN.ObtenerColaboradoresXId(Id);

                return Json(usuario, JsonRequestBehavior.AllowGet);
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
        public ActionResult DiasLibresColaboradores()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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

        public ActionResult CerrarSession()
        {
            try
            {
                Session["Usuario"] = null;
                return RedirectToAction("Login", "Home");
            }
            catch (Exception ex)
            {
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;


                LN.InsertarBitacora(bitacora);

                return Json(false, JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult AsignarServiciosColaborador()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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

        public JsonResult AsignarServiciosXColaborador(Usuario UsuarioXServicio)

        {
            int Respuesta = 0;

            try
            {
                usuario = (Usuario)Session["Usuario"];

                Respuesta = LN.AsignarServiciosXColaborador(UsuarioXServicio);


            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;


                LN.InsertarBitacora(bitacora);


            }

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaServiciosXColaborador()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
                {

                    Menu = ArmarMenu(usuario.Id);

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

        public JsonResult ObtenerServiciosXColaborador()
        {
            List<Usuario> ServiciosXColaborador = new List<Usuario>();
            try
            {
                

                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {
                    ServiciosXColaborador = LN.ObtenerServiciosXColaborador(usuario.IdEmpresa);
                }


                
            }
            catch (Exception ex)
            {
                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;

                LN.InsertarBitacora(bitacora);
                
            }
            return Json(ServiciosXColaborador, JsonRequestBehavior.AllowGet);

        }

        public JsonResult EliminarServiciosXColaborador(int Id)
        {
            bool SeElimino = false;
            try
            {
               

                SeElimino = LN.EliminarServiciosXColaborador(Id);

               
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

        public JsonResult DesactivarActivarServicioXColaborador(int Id, bool Estado)
        {
            bool SeActualizoEstado = false;

            try
            {               

                SeActualizoEstado = LN.DesactivarActivarServicioXColaborador(Id, Estado);
                
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


        public JsonResult ObtenerServiciosXColaboradorXId(int IdColaborador)
        {
            try
            {
                List<Usuario> usuario = new List<Usuario>();

                usuario = LN.ObtenerServiciosXColaboradorXId(IdColaborador);

                return Json(usuario, JsonRequestBehavior.AllowGet);
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

                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult ValidarCorreoElectronico(int Id, string CorreoElectronico)
        {
            int Respuesta = 1;
            try
            {
                
                Respuesta = LN.ValidarCorreoElectronico(Id, CorreoElectronico);
               
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

        public JsonResult EditarContrasenaXCorreoElectronico(Login login)
        {
            int Respuesta = 0;
            try
            {
                usuario = (Usuario)Session["Usuario"];
                
                Respuesta = LN.EditarContrasenaXCorreoElectronico(login, usuario.CorreoElectronico);
                
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
        public ActionResult ActualizarContrasenaXCorreoElectronico()

        {
            usuario = (Usuario)Session["Usuario"];
            Menu = ArmarMenu(usuario.Id);

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
        public ActionResult ActualizarPerfil()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {


                Menu = ArmarMenu(usuario.Id);
                Usuario perfil = new Usuario();
                if (usuario != null)
                {
                    if (usuario.Id > 0)
                    {
                        ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                        ViewBag.Menu = Menu;
                        perfil = LN.ObtenerPerfilColaboradorXId(usuario.Id);
                        return View("ActualizarPerfil", perfil);
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


        public JsonResult ValidarCorreoElectronicoPerfil(string CorreoElectronico)
        {
            int Respuesta = 1;

            try
            {
                usuario = (Usuario)Session["Usuario"];
                
                Respuesta = LN.ValidarCorreoElectronico(usuario.Id, CorreoElectronico);
                
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

        public JsonResult ActualizarPerfil(Usuario perfil)
        {
            bool SeActualizo = false;
            try
            {
                usuario = (Usuario)Session["Usuario"];
                
                perfil.UsuarioUltimaModificacion = usuario.NombreCompleto;
                perfil.Id = usuario.Id;
                perfil.IdRol = usuario.IdRol;
                SeActualizo = LN.ActualizarPerfil(perfil);

                
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

        public JsonResult OlvidoContrasena(string CorreoElectronico)
        {

            bool Correcto = false;

            try
            {
                int ExisteCorreo = LN.ValidarCorreo_OlvidoContrasena(CorreoElectronico.Trim());

                if (ExisteCorreo == 1)
                {

                    string ContrasenaTemporal = utilidades.ObtenerClaveTemporal();
                    bool SeActualizo = LN.ActualizarContrasena(CorreoElectronico, ContrasenaTemporal);
                    
                    Correo correo = new Correo();
                    correo.Subject = "Contraseña Temporal Sistema Citas";
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
                                        <h1 style=""color:#1e1e2d; font-weight:500; margin:0;font-size:32px;font-family: Rubik,sans-serif;"">Ha solicitado restablecer su contraseña</h1>
                                        <span style=""display:inline-block; vertical-align:middle; margin:29px 0px 26px; border-bottom:1px solid #cecece; width:100px;""></span>
                                        <p style=""color:#455056; font-size:15px;line-height:24px; margin:0;"">
                                            No podemos simplemente enviarle su contraseña anterior.
                                            Se ha generado una contraseña aleatoria para restablecerla.
                                            Porfavor ingrese al sistema y realice el cambio por su seguridad.                                           

                                        </p>  
                                            <p style=""height:20px; font-size:25px;"">&darr;</p>

                                        <p style=""background:#20e277;text-decoration:none !important; font-weight:500; color:#fff;font-size:14px;padding:10px 24px;display:inline-block;border-radius:50px;"">{0}</p>
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
                            <p style=""font-size:14px; color:rgba(69, 80, 86, 0.7411764705882353); line-height:18px; margin:0px 0px 0px;"">Copyright &copy; {1} </p>
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
                                ", ContrasenaTemporal,DateTime.Now.Year);
                    correo.Body = BODY;                       
                    correo.To = CorreoElectronico;

                    bool SeEnvioCorreo = utilidades.EnviarCorreoGenerico(correo);

                    if (SeActualizo)
                    {
                        Correcto = true;
                    }

                }

            }
            catch (Exception ex)
            {

                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);
                                
            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

    }
}