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

        public JsonResult Loguear(Login login)
        {
            Usuario usuario = LN.Validarlogin(login);
            Session["Usuario"] = usuario;
            ArmarMenu(usuario.Id);
            return Json(usuario,JsonRequestBehavior.AllowGet);
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
            Menu = (string)Session["Menu"];

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

        [HttpPost]
        public JsonResult InsertarDatosColaborador(Usuario usuario)
        {
            int Resp = 0;
            LN.InsertarDatosColaborador(usuario, ref Resp);

            return Json(usuario, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerColaboradoresActivos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = LN.ObtenerColaboradoresActivos();

            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerTodosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = LN.ObtenerTodosUsuarios();

            return Json(usuarios, JsonRequestBehavior.AllowGet);
        }

      

    }
}