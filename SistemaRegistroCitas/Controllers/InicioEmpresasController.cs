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
    public class InicioEmpresasController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();

        // GET: InicioEmpresas
        
        public ActionResult InicioEmpresas()
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
        
        public JsonResult ObtenerEmpresasXId()
        {
            Empresa empresa = new Empresa();
            int EmpresaUsuario = 0;
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {
                if (usuario.IdRol == 4)
                {
                    var IdEmpresa = Request.UrlReferrer.ToString().Split('=')[1];
                    EmpresaUsuario = Convert.ToInt32(IdEmpresa);

                }
                else
                {
                    EmpresaUsuario = usuario.IdEmpresa;

                }

                empresa = LN.paObtenerEmpresasXId(EmpresaUsuario);

                return Json(empresa, JsonRequestBehavior.AllowGet);

            }
            else {

                return Json(null, JsonRequestBehavior.AllowGet);


            }

              
        }


    }
}