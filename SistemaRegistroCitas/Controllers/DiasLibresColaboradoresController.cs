using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class DiasLibresColaboradoresController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();

        // GET: DiasLibresColaboradores
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult DesactivarActivarDiasLibres(bool Lunes, bool Martes, bool Miercoles, bool Jueves, bool Viernes, bool Sabado, bool Domingo, int IdColaborador)
        {

            bool SeActualizoDiasLibres = false;

            SeActualizoDiasLibres = LN.DesactivarActivarDiasLibres(Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, IdColaborador);

            return Json(SeActualizoDiasLibres, JsonRequestBehavior.AllowGet);
        }

    }
}