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
            try
            {               

                usuario = (Usuario)Session["Usuario"];

                int Resp = 0;
                LN.InsertarUsuario(usuario, ref Resp);

                return Json(Resp, JsonRequestBehavior.AllowGet);
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

        public JsonResult ObtenerUsuarioSesion() {

            try
            {
                Usuario usuarioSession = new Usuario();
                if (Session["Usuario"] != null)
                {

                    usuarioSession = (Usuario)Session["Usuario"];
                }
                return Json(usuarioSession, JsonRequestBehavior.AllowGet);

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

     

        public List<Menu> ObtenerMenuUsuario(int IdUsuario)
        {

            List<Menu> ListaMenu = new List<Menu>();

            try
            {
                ListaMenu = LN.ObtenerMenuUsuario(IdUsuario);
            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaMenu;
        }


        public string ArmarMenu(int IdUsuario)
        {

            List<Menu> menu = ObtenerMenuUsuario(IdUsuario);


            StringBuilder menuArmado = new StringBuilder();
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

            else {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
           
        }
       
  
        public JsonResult InsertarDatosColaborador(Usuario usuario)
        {
            try
            {                

                int Resp = 0;
                Usuario usu = (Usuario)Session["Usuario"];
                usuario.IdEmpresa = usu.IdEmpresa;
                LN.InsertarDatosColaborador(usuario, ref Resp);

                return Json(Resp, JsonRequestBehavior.AllowGet);
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

        public JsonResult ActualizarColaboradores(Usuario usuario)
        {
            try
            {
                bool SeActualizo = false;
                usuario.UsuarioUltimaModificacion = usuario.NombreCompleto;
                SeActualizo = LN.ActualizarColaboradores(usuario);

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

            try
            {
                usuario = (Usuario)Session["Usuario"];

                int Respuesta = LN.AsignarServiciosXColaborador(UsuarioXServicio);

                return Json(Respuesta, JsonRequestBehavior.AllowGet);
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

            try
            {
                List<Usuario> ServiciosXColaborador = new List<Usuario>();

                usuario = (Usuario)Session["Usuario"];

                if (usuario != null)
                {
                    ServiciosXColaborador = LN.ObtenerServiciosXColaborador(usuario.IdEmpresa);
                }


                return Json(ServiciosXColaborador, JsonRequestBehavior.AllowGet);
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

                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult EliminarServiciosXColaborador(int Id)
        {
            try
            {
                bool SeElimino = false;

                SeElimino = LN.EliminarServiciosXColaborador(Id);

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

        public JsonResult DesactivarActivarServicioXColaborador(int Id, bool Estado)
        {

            try
            {
                bool SeActualizoEstado = false;

                SeActualizoEstado = LN.DesactivarActivarServicioXColaborador(Id, Estado);

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

                return Json(false, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult ValidarCorreoElectronico(int Id, string CorreoElectronico)
        {
            try
            {
                int Respuesta = 1;
                Respuesta = LN.ValidarCorreoElectronico(Id, CorreoElectronico);
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

        public JsonResult EditarContrasenaXCorreoElectronico(Login login)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];
                int Respuesta = 0;
                Respuesta = LN.EditarContrasenaXCorreoElectronico(login, usuario.CorreoElectronico);
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
                        return View("ActualizarPerfil",perfil);
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


        //public JsonResult ObtenerPerfilColaboradorXId()
        //{
        //    try
        //    {
        //        Usuario perfil = new Usuario();

        //        usuario = (Usuario)Session["Usuario"];

        //        perfil = LN.ObtenerPerfilColaboradorXId(usuario.Id);

        //        return Json(perfil, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        usuario = (Usuario)Session["Usuario"];
        //        var bitacora = new Bitacora();
        //        bitacora.Clase = this.GetType().Name;
        //        bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
        //        bitacora.Error = ex.Message.ToString();
        //        bitacora.UsuarioCreacion = usuario.NombreCompleto;


        //        LN.InsertarBitacora(bitacora);

        //        return Json(false, JsonRequestBehavior.AllowGet);
        //    }

        //}

        public JsonResult ValidarCorreoElectronicoPerfil(string CorreoElectronico)
        {

            try
            {
                usuario = (Usuario)Session["Usuario"];
                int Respuesta = 1;
                Respuesta = LN.ValidarCorreoElectronico(usuario.Id, CorreoElectronico);
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

        public JsonResult ActualizarPerfil(Usuario perfil)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];
                bool SeActualizo = false;
                perfil.UsuarioUltimaModificacion = usuario.NombreCompleto;
                perfil.Id = usuario.Id;
                perfil.IdRol = usuario.IdRol;
                SeActualizo = LN.ActualizarColaboradores(perfil);

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

        public JsonResult OlvidoContrasena(string CorreoElectronico) 
        {

            bool Correcto = false;
           
            try
            {
                int ExisteCorreo = LN.ValidarCorreo_OlvidoContrasena(CorreoElectronico.Trim());

                if (ExisteCorreo == 1) {

                    string ContrasenaTemporal = utilidades.ObtenerClaveTemporal();
                    bool SeActualizo = LN.ActualizarContrasena(CorreoElectronico, ContrasenaTemporal);

                    Correo correo = new Correo();
                    correo.Subject = "Contraseña Temporal Sistema Citas";
                    correo.Body = "Su nueva contraseña temporal es " + ContrasenaTemporal + " ,porfavor ingrese al sistema y realice el cambio por su seguridad.";
                    correo.To = CorreoElectronico;

                    bool SeEnvioCorreo = utilidades.EnviarCorreoGenerico(correo);

                    if (SeActualizo) {
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

                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(Correcto, JsonRequestBehavior.AllowGet);
        }

    }
}