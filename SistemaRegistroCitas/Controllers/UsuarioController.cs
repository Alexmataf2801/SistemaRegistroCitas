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



        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarUsuario(Usuario usuario)
        {
            int Resp = 0;
            LN.InsertarUsuario(usuario, ref Resp);

            return Json(Resp, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Loguear(Login login, int IdEmpresa)
        {
            Usuario usuario = LN.Validarlogin(login, IdEmpresa);
            Session["Usuario"] = usuario;
            ArmarMenu(usuario.Id);
            //Session["EmpresaSeleccionada"] = IdEmpresa;
            //CargarConfiguracionesEmpresa(IdEmpresa);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        public void CargarConfiguracionesEmpresa(int IdEmpresa) {
            //ColaboradoresEmpresa(IdEmpresa); // Carga Colaboradores empresa en el combo
            //ObtenerCalendarioEmpresa(IdEmpresa); // Nos carga todos los eventos de la empresa en el calendario

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

  
        public JsonResult InsertarDatosColaborador(Usuario usuario)
        {
            int Resp = 0;
            Usuario usu = (Usuario)Session["Usuario"];
            usuario.IdEmpresa = usu.IdEmpresa;
            LN.InsertarDatosColaborador(usuario, ref Resp);

            return Json(Resp, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerColaboradoresActivos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
               
                usuarios = LN.ObtenerColaboradoresActivos(usuario.IdEmpresa);

            }            

            return Json(usuarios, JsonRequestBehavior.AllowGet);
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
            

            if (usuario != null)
            {
                Menu = ArmarMenu(usuario.Id);

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


        public JsonResult ObtenerTodosLosColaboradores()
        {
            List<Usuario> usuarios = new List<Usuario>();
            
            usuario = (Usuario)Session["Usuario"];

           if(usuario != null)
            {
                usuarios = LN.ObtenerTodosLosColaboradores(usuario.IdEmpresa);
 
            }

                  
            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DesactivarActivarColaboradores(int Id, bool Estado)
        {

            bool SeActualizoEstado = false;

            SeActualizoEstado = LN.DesactivarActivarColaboradores(Id, Estado);

            return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarColaboradores(int Id)
        {
            bool SeElimino = false;

            SeElimino = LN.EliminarColaboradores(Id);

            return Json(SeElimino, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult ActualizarColaboradores()
        {
            usuario = (Usuario)Session["Usuario"];
            

            if (usuario != null)
            {
                Menu = ArmarMenu(usuario.Id);

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

        public JsonResult ActualizarColaboradores(Usuario usuario)
        {
            
            bool SeActualizo = false;
            usuario.UsuarioUltimaModificacion = usuario.NombreCompleto;
            SeActualizo = LN.ActualizarColaboradores(usuario);

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }


        public JsonResult ObtenerColaboradoresXId(int Id)
        {
            Usuario usuario = new Usuario();

            usuario = LN.ObtenerColaboradoresXId(Id);

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult DiasLibresColaboradores()
        {
            usuario = (Usuario)Session["Usuario"];


            if (usuario != null)
            {
                Menu = ArmarMenu(usuario.Id);

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

        public ActionResult CerrarSession()
        {
            Session["Usuario"] = null;
            return RedirectToAction("Login", "Home");
        }

        [HttpGet]
        public ActionResult AsignarServiciosColaborador()
        {
            usuario = (Usuario)Session["Usuario"];


            if (usuario != null)
            {
                Menu = ArmarMenu(usuario.Id);

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

        public JsonResult AsignarServiciosXColaborador(Usuario UsuarioXServicio)

        {
            
            int Respuesta = LN.AsignarServiciosXColaborador(UsuarioXServicio);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaServiciosXColaborador()
        {
            usuario = (Usuario)Session["Usuario"];


            if (usuario != null)
            {
                Menu = ArmarMenu(usuario.Id);

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

        public JsonResult ObtenerServiciosXColaborador()
        {
            List<Usuario> ServiciosXColaborador = new List<Usuario>();

            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {                
                ServiciosXColaborador = LN.ObtenerServiciosXColaborador(usuario.IdEmpresa);
            }
            

            return Json(ServiciosXColaborador, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EliminarServiciosXColaborador(int Id)
        {
            bool SeElimino = false;

            SeElimino = LN.EliminarServiciosXColaborador(Id);

            return Json(SeElimino, JsonRequestBehavior.AllowGet);


        }

        public JsonResult DesactivarActivarServicioXColaborador(int Id, bool Estado)
        {

            bool SeActualizoEstado = false;

            SeActualizoEstado = LN.DesactivarActivarServicioXColaborador(Id, Estado);

            return Json(SeActualizoEstado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerServiciosXColaboradorXId(int IdColaborador)
        {
            List<Usuario> usuario = new List<Usuario>();

            usuario = LN.ObtenerServiciosXColaboradorXId(IdColaborador);

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

    }
}