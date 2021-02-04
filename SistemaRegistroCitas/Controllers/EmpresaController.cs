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

        //public ActionResult ObtenerHorarioEmpresa()
        //{
        //    HorarioEmpresa horarioEmpresa = new HorarioEmpresa();

        //    Usuario usu = (Usuario)Session["Usuario"];

        //    horarioEmpresa = LN.ObtenerHorarioEmpresa(usu.IdEmpresa);

        //    return View("InicioEmpresas", horarioEmpresa);
        //}

    }
}