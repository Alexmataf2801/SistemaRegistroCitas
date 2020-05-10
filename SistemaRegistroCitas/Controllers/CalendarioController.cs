using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class CalendarioController : Controller
    {
        Usuario usuario = new Usuario();

        // GET: Calendario
        public ActionResult Calendario()
        {
            usuario  = (Usuario)Session["Usuario"];

            if (usuario != null) {
                if (usuario.Id > 0)
                {
                    ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
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

    }
}