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
            try
            {
                
                empresas = LN.ObtenerNombresEmpresasActivas();

                
            }
            catch (Exception ex)
            {
                               
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = " ";


                LN.InsertarBitacora(bitacora);

            }
            return Json(empresas, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerHorarioEmpresa()
        {
            HorarioEmpresa horarioEmpresa = new HorarioEmpresa();
            try
            {
                

                Usuario usu = (Usuario)Session["Usuario"];

                horarioEmpresa = LN.ObtenerHorarioEmpresa(usu.IdEmpresa);
                horarioEmpresa.IdEmpresa = usu.IdEmpresa;
                Session["HorarioEmpresa"] = horarioEmpresa;
                
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

               
            }
            return Json(horarioEmpresa, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ActualizarDatosXIdEmpresa(Empresa empresa)
        {
            bool SeActualizo = false;
            try
            {
                usuario = (Usuario)Session["Usuario"];
               
                SeActualizo = LN.ActualizarDatosXIdEmpresa(empresa, usuario.IdEmpresa);
                               
            }
            catch (Exception ex)
            {

                usuario = (Usuario)Session["Usuario"];
                var bitacora = new Bitacora();
                bitacora.Clase = this.GetType().Name;
                bitacora.Metodo = System.Reflection.MethodBase.GetCurrentMethod().Name;
                bitacora.Error = ex.Message.ToString();
                bitacora.UsuarioCreacion = usuario.NombreCompleto;


                LN.InsertarBitacora(bitacora);

                
            }

            return Json(SeActualizo, JsonRequestBehavior.AllowGet);


        }

        [HttpGet]
        public ActionResult ActualizarInicioEmpresa()
        {
            usuario = (Usuario)Session["Usuario"];

            if (!usuario.CTemp)
            {
                if (usuario.IdRol == 1 || usuario.IdRol == 2)
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
                    return RedirectToAction("InicioEmpresas", "InicioEmpresas");
                }
            }
            else
            {
                return RedirectToAction("ActualizarContrasenaXCorreoElectronico", "Usuario");
            }
        }



    }
}