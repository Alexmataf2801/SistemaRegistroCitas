using Entidades;
using Entidades.ClasesEntidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class EventoController : Controller
    {
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }
    }
}