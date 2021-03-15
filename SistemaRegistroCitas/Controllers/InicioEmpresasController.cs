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


            if (!usuario.CTemp)
            {

                Menu = usuarioControllador.ArmarMenu(usuario.Id);//(String)Session["Menu"];
                HorarioEmpresa horarioEmpresa = new HorarioEmpresa();

                if (usuario != null)
                {
                    if (usuario.Id > 0)
                    {
                        ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                        ViewBag.Menu = Menu;

                        horarioEmpresa = LN.ObtenerHorarioEmpresa(usuario.IdEmpresa);

                        return View("InicioEmpresas", horarioEmpresa);

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
            else
                {
                    return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
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
                    //var IdEmpresa = Request.UrlReferrer.ToString().Split('=')[1];
                    EmpresaUsuario = Convert.ToInt32(usuario.IdEmpresa);

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

        [HttpGet]
        public ActionResult InsertarHorarioEmpresa()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {

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
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }

        public JsonResult InsertarHorarioEmpresa(HorarioEmpresa horarioEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)

        {

            usuario = (Usuario)Session["Usuario"];

            int Respuesta = LN.InsertarHorarioEmpresa(horarioEmpresa, usuario.IdEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves, EstadoViernes, EstadoSabado, EstadoDomingo);

            return Json(Respuesta, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ActualizarHorarioEmpresa()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {

                Menu = usuarioControllador.ArmarMenu(usuario.Id);
                HorarioEmpresa horarioEmpresa = new HorarioEmpresa();

            if (usuario != null)
            {
                if (usuario.Id > 0)
                {
                    ViewBag.Usuario = usuario.Nombre + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
                    ViewBag.Menu = Menu;

                    horarioEmpresa = LN.ObtenerHorarioEmpresa(usuario.IdEmpresa);

                    return View("ActualizarHorarioEmpresa", horarioEmpresa);
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
            else
                {
                    return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
                }
        }


        public JsonResult ActualizarHorarioEmpresa(HorarioEmpresa horarioEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)
        {
            usuario = (Usuario)Session["Usuario"];
            int SeActualizo = 0;
            SeActualizo = LN.ActualizarHorarioEmpresa(horarioEmpresa,usuario.IdEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves, EstadoViernes, EstadoSabado, EstadoDomingo);

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);

        }

        
    }
}