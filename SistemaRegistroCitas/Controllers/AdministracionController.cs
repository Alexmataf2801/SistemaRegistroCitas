using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;


namespace SistemaRegistroCitas.Controllers
{
    public class AdministracionController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();
        // GET: Administracion
        public ActionResult Index()
        {
            usuario = (Usuario)Session["Usuario"];
            Menu = usuarioControllador.ArmarMenu(usuario.Id);//(String)Session["Menu"];

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



        public JsonResult ObtenerMenuGeneral()
        {
            List<Menu> menu = new List<Menu>();
            StringBuilder sb = new StringBuilder();
            try
            {
                menu = LN.ObtenerMenuGeneral();

                var listaPadres = menu.Where(p => p.IsPadre == "0").ToList();
                //onclick='OnTreeClick(event)'
                sb.Append("<ul id='RaizArbol'  class='treeview-menu' style='display: block;'>");
                for (int i = 0; i < listaPadres.Count; i++)
                {

                    sb.Append("<li id='" + listaPadres[i].IdMenu + "'><i class='fa fa-caret'></i><input name='" + listaPadres[i].IdMenu + "' type='checkbox' id='" + listaPadres[i].IdMenu + "' />" + listaPadres[i].Nombre);

                    var ListaSegundoNivel = menu.Where(p => p.IdPadre == listaPadres[i].IdMenu).ToList();

                    if (ListaSegundoNivel.Count > 0)
                    {

                        sb.Append("<ul style='display: block;' class='treeview-menu'>");
                    }
                    else
                    {
                        sb.Append("</li>");
                    }

                    for (int j = 0; j < ListaSegundoNivel.Count; j++)
                    {
                        sb.Append("<li id='" + ListaSegundoNivel[j].IdMenu + "'><i class='fa fa-caret'></i><input name='" + listaPadres[i].IdMenu + "' type='checkbox' id='" + ListaSegundoNivel[j].IdMenu + "' />" + ListaSegundoNivel[j].Nombre);

                        var ListaTercerNivel = menu.Where(p => p.IdPadre == ListaSegundoNivel[j].IdMenu).ToList();

                        if (ListaTercerNivel.Count > 0)
                        {

                            sb.Append("<ul style='display: block;' class='treeview-menu'>");
                        }
                        else
                        {
                            sb.Append("</li>");
                        }

                        for (int k = 0; k < ListaTercerNivel.Count; k++)
                        {
                            sb.Append("<li id='" + ListaTercerNivel[k].IdMenu + "'><i class='fa fa-caret'></i><input name='" + listaPadres[i].IdMenu + "' type='checkbox' id='" + ListaTercerNivel[k].IdMenu + "' />" + ListaTercerNivel[k].Nombre);


                            var ListaCuartoNivel = menu.Where(p => p.IdPadre == ListaTercerNivel[k].IdMenu).ToList();


                            if (ListaCuartoNivel.Count > 0)
                            {

                                sb.Append("<ul style='display: block;' class='treeview-menu'>");
                            }
                            else
                            {
                                sb.Append("</li>");
                            }

                            for (int m = 0; m < ListaCuartoNivel.Count; m++)
                            {
                                sb.Append("<li id='" + ListaCuartoNivel[m].IdMenu + "'><i class='fa fa-caret'></i><input name='" + listaPadres[i].IdMenu + "' type='checkbox' id='" + ListaCuartoNivel[m].IdMenu + "' />" + ListaCuartoNivel[m].Nombre + "</li>");
                            }

                        }


                        if (ListaTercerNivel.Count > 0)
                        {
                            sb.Append("</ul>");
                        }
                        else
                        {
                            sb.Append("</li>");
                        }


                    }


                    sb.Append("</ul>");
                }

                sb.Append("</li></ul>");

            }
            catch (Exception ex)
            {

            }

            return Json(sb.ToString(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult InsertarPermisosXUsuario(int IdUsuario, List<int> ListaPermisos)
        {
            bool Correcto = false;

            Correcto = LN.InsertarPermisosXUsuario(IdUsuario, ListaPermisos);

            return Json(Correcto, JsonRequestBehavior.AllowGet);

        }


    }
}