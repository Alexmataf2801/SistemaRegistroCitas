using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaRegistroCitas.Controllers
{
    public class UnidadMedidaController : Controller
    {
        Usuario usuario = new Usuario();
        UsuarioController usuarioControllador = new UsuarioController();
        LogicaNegocio.LogicaNegocio LN = new LogicaNegocio.LogicaNegocio();
        

        // GET: UnidadMedida
        public ActionResult InsertarUnidadMedida()
        {
            return View();
        }

        public JsonResult ObtenerMinutosYHoras()
        {
            try
            {
                List<UnidadMedida> unidadMedida = new List<UnidadMedida>();
                unidadMedida = LN.ObtenerMinutosYHoras();

                return Json(unidadMedida, JsonRequestBehavior.AllowGet);
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

                return Json(false, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}