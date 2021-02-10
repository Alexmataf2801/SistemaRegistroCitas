using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class EmpresaController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();
        // GET: Empresa
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ObtenerNombresEmpresasActivas()
        {
            List<Empresa> empresas = new List<Empresa>();

            empresas = LN.ObtenerNombresEmpresasActivas();

            return Json(empresas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerHorarioEmpresa()
        {
            HorarioEmpresa horarioEmpresa = new HorarioEmpresa();

            Usuario usu = (Usuario)Session["Usuario"];

            horarioEmpresa = LN.ObtenerHorarioEmpresa(usu.IdEmpresa);
            horarioEmpresa.IdEmpresa = usu.IdEmpresa;
            Session["HorarioEmpresa"] = horarioEmpresa;
            return Json(horarioEmpresa, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActualizarDatosXIdEmpresa(Empresa empresa)
        {
            usuario = (Usuario)Session["Usuario"];
            bool SeActualizo = false;
            SeActualizo = LN.ActualizarDatosXIdEmpresa(empresa, usuario.IdEmpresa);

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public ActionResult ActualizarInicioEmpresa()
        {
            usuario = (Usuario)Session["Usuario"];
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






        //public ActionResult ObtenerHorarioEmpresa()
        //{
        //    HorarioEmpresa horarioEmpresa = new HorarioEmpresa();

        //    Usuario usu = (Usuario)Session["Usuario"];

        //    horarioEmpresa = LN.ObtenerHorarioEmpresa(usu.IdEmpresa);

        //    return View("InicioEmpresas", horarioEmpresa);
        //}

    }
}