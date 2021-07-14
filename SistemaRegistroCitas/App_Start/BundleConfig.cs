using System.Web;
using System.Web.Optimization;

namespace SistemaRegistroCitas
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
           

            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            //// para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));


            bundles.Add(new StyleBundle("~/Estilos/bootstrap").Include(
                            "~/Estilos/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/Eventos").Include("~/Scripts/Propios/Eventos*"));
            bundles.Add(new ScriptBundle("~/bundles/Servicio").Include("~/Scripts/Propios/Servicio*"));
            bundles.Add(new ScriptBundle("~/bundles/Colaboradores").Include("~/Scripts/Propios/Colaboradores*"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/ActualizarInicioEmpresa").Include("~/Scripts/Propios/ActualizarInicioEmpresa*"));

            bundles.Add(new ScriptBundle("~/bundles/ListaEventos").Include("~/Scripts/Propios/ListaEventos*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaEventoHorasLibres").Include("~/Scripts/Propios/ListaEventoHorasLibres*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaEventoUsuario").Include("~/Scripts/Propios/ListaEventoUsuario*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaEventoUsuarioCreador").Include("~/Scripts/Propios/ListaEventoUsuarioCreador*"));

            bundles.Add(new ScriptBundle("~/bundles/ActualizarHorarioEmpresa").Include("~/Scripts/Propios/ActualizarHorarioEmpresa*"));
            bundles.Add(new ScriptBundle("~/bundles/InicioEmpresas").Include("~/Scripts/Propios/InicioEmpresas*"));
            bundles.Add(new ScriptBundle("~/bundles/InicioEmpresas").Include("~/Scripts/Propios/InicioEmpresas*"));

            bundles.Add(new ScriptBundle("~/bundles/ActualizarDatosColaborador").Include("~/Scripts/Propios/ActualizarDatosColaborador*"));
            bundles.Add(new ScriptBundle("~/bundles/ValidarCorreoElectronico").Include("~/Scripts/Propios/ValidarCorreoElectronico*"));
            bundles.Add(new ScriptBundle("~/bundles/MostrarYOcutarContrasenaActual").Include("~/Scripts/Propios/MostrarYOcutarContrasenaActual*"));
            bundles.Add(new ScriptBundle("~/bundles/MostrarYOcultarContrasenaNueva").Include("~/Scripts/Propios/MostrarYOcultarContrasenaNueva*"));
            bundles.Add(new ScriptBundle("~/bundles/MostrarYOcultarContrasenaConfirmar").Include("~/Scripts/Propios/MostrarYOcultarContrasenaConfirmar*"));
            bundles.Add(new ScriptBundle("~/bundles/EditarContrasenaXCorreoElectronico").Include("~/Scripts/Propios/EditarContrasenaXCorreoElectronico*"));
            bundles.Add(new ScriptBundle("~/bundles/ObtenerPerfilColaboradorXId").Include("~/Scripts/Propios/ObtenerPerfilColaboradorXId*"));
            bundles.Add(new ScriptBundle("~/bundles/AsignarServiciosColaborador").Include("~/Scripts/Propios/AsignarServiciosColaborador*"));           
            bundles.Add(new ScriptBundle("~/bundles/Colaboradores").Include("~/Scripts/Propios/Colaboradores*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaColaboradores").Include("~/Scripts/Propios/ListaColaboradores*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaServiciosXColaborador").Include("~/Scripts/Propios/ListaServiciosXColaborador*"));

            bundles.Add(new ScriptBundle("~/bundles/ActualizarDatosServicios").Include("~/Scripts/Propios/ActualizarDatosServicios*"));
            bundles.Add(new ScriptBundle("~/bundles/Servicio").Include("~/Scripts/Propios/Servicio*"));
            bundles.Add(new ScriptBundle("~/bundles/ListaServicios").Include("~/Scripts/Propios/ListaServicios*"));

            bundles.Add(new ScriptBundle("~/bundles/Usuario").Include("~/Scripts/Propios/Usuario*"));
            bundles.Add(new ScriptBundle("~/bundles/Empresa").Include("~/Scripts/Propios/Empresa*"));
            bundles.Add(new ScriptBundle("~/bundles/MostrarYOcutarContrsena").Include("~/Scripts/Propios/MostrarYOcutarContrsena*"));
            bundles.Add(new ScriptBundle("~/bundles/OlvidarContrasena").Include("~/Scripts/Propios/OlvidarContrasena*"));



            BundleTable.EnableOptimizations = true;

        }
    }
}
