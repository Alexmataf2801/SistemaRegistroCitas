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
    public class EventosController : Controller
    {
        Usuario usuario = new Usuario();
        string Menu = string.Empty;
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        UsuarioController usuarioControllador = new UsuarioController();
        EmpresaController empresaController = new EmpresaController();

        // GET: Eventos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult InsertarEventos(Eventos eventos)

        {
           
            usuario = (Usuario)Session["Usuario"];
            eventos.UsuarioCreacion = usuario.NombreCompleto;
            eventos.IdUsuarioCrecion = usuario.Id;
            int Respuesta = 0;

            TimeSpan HoraInicio = eventos.HorarioInicial.TimeOfDay;
            TimeSpan HoraFin = eventos.HoraFinal.TimeOfDay;

            if (ValidarHoraEvento(eventos.IdDia, HoraInicio.ToString(), HoraFin.ToString()))
            {
                Respuesta = LN.InsertarEventos(eventos, usuario.IdEmpresa, usuario.IdRol);
            }
            else
            {
                Respuesta = 5;
            }

             

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        public bool ValidarHoraEvento(int Dia, string Inicio, string Final)
        {
            HorarioEmpresa horarioEmpresa = new HorarioEmpresa();
            horarioEmpresa = (HorarioEmpresa)Session["HorarioEmpresa"];

            bool Respuesta = false;

            switch (Dia)
            {

                case 0:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {

                        if (horarioEmpresa.InicioDomingo <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalDomingo >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }

                    }

                    break;
                case 1:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {


                        if (horarioEmpresa.InicioLunes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalLunes >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                    }

                    break;
                case 2:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    { 
                        if (horarioEmpresa.InicioMartes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalMartes >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                     }
                    break;
                case 3:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {
                        if (horarioEmpresa.InicioMiercoles <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalMiercoles >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                    }

                    break;
                case 4:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {
                        if (horarioEmpresa.InicioJueves <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalJueves >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                    }

                    break;
                case 5:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {
                        if (horarioEmpresa.InicioViernes <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalViernes >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                    }

                    break;
                case 6:
                    if (TimeSpan.Parse(Inicio) < TimeSpan.Parse(Final))
                    {
                        if (horarioEmpresa.InicioSabado <= TimeSpan.Parse(Inicio) && horarioEmpresa.FinalSabado >= TimeSpan.Parse(Final))
                        {
                            Respuesta = true;
                        }
                    }

                    break;
                default:
                    break;
            }

            return Respuesta;

        }


        public JsonResult ObtenerTodosLosEventosXIdEmpresa()
        {
            List<Eventos> Eventos = new List<Eventos>();
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {

                Eventos = LN.ObtenerTodosLosEventosXIdEmpresa(usuario.IdEmpresa);
            }


            return Json(Eventos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ListaEvento()
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

        public JsonResult EliminarEventos(int Id)
        {
            bool SeElimino = false;

            SeElimino = LN.EliminarEventos(Id);

            return Json(SeElimino, JsonRequestBehavior.AllowGet);


        }

    }
}