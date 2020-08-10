
using Entidades;
using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LogicaNegocio
    {
        private AccesoDatos.AccesoDatos AD = new AccesoDatos.AccesoDatos();


        #region INSERTS
        public void InsertarUsuario(Usuario usuario, ref int Resp)
        {

            AD.InsertarUsuario(usuario, ref Resp);

        }

        public bool InsertarEvento(Evento evento)
        {

            return AD.InsertarEvento(evento);
        }

        public bool InsertarRoles(Roles roles)
        {
            return AD.InsertarRoles(roles);
        }

        public bool InsertarDatosServicios(Servicio servicio)
        {
            return AD.InsertarDatosServicios(servicio);
        }

        public void InsertarDatosColaborador(Usuario usuario, ref int Resp)
        {

            AD.InsertarDatosColaborador(usuario, ref Resp);

        }

        public bool InsertarPermisosXUsuario(int IdUsuario, List<int> ListaPermisos)
        {
            return AD.InsertarPermisosXUsuario(IdUsuario, ListaPermisos);
        }

        public bool InsertarUnidadMedida(UnidadMedida unidadMedida)
        {
            return AD.InsertarUnidadMedida(unidadMedida);
        }

        #endregion


        #region UPDATES

        public bool ActualizarRol(Roles rol)
        {

            return AD.ActualizarRol(rol);
        }

        public bool DesactivarActivarRol(int IdRol, bool Estado)
        {
            return AD.DesactivarActivarRol(IdRol, Estado);
        }

        public bool ActualizarServicios(Servicio servicio)
        {
            return AD.ActualizarServicios(servicio);
        }

        public bool DesactivarActivarServicios(int Id, bool Estado)
        {
            return AD.DesactivarActivarServicios(Id, Estado);
        }

        public bool ActualizarColaboradores (Usuario usuario)
        {
            return AD.ActualizarColaboradores(usuario);
        }

        public bool DesactivarActivarColaboradores(int Id, bool Estado)
        {
            return AD.DesactivarActivarColaboradores(Id, Estado);
        }

        public bool DesactivarActivarDiasLibres(bool Lunes, bool Martes, bool Miercoles, bool Jueves, bool Viernes, bool Sabado, bool Domingo, int IdColaborador)
        {
            return AD.DesactivarActivarDiasLibres(Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, IdColaborador);
        }

        #endregion


        #region DELETES

        public bool EliminarRol(int IdRol)
        {
            return AD.EliminarRol(IdRol);
        }

        public bool EliminarServicios(int Id)
        {
            return AD.EliminarServicios(Id);
        }

        public bool EliminarColaboradores(int Id)
        {
            return AD.EliminarColaboradores(Id);
        }

        #endregion


        #region SELECTS
        public List<Servicio> ObtenerServicios()
        {
            return AD.ObtenerServicios();
        }

        public Usuario Validarlogin(Login login, int IdEmpresa)
        {
            return AD.Validarlogin(login, IdEmpresa);
        }

        public Servicio ServicioXId(int IdServicio)
        {
            return AD.ServicioXId(IdServicio);
        }

        public List<Menu> ObtenerMenuUsuario(int IdUsuario)
        {
            return AD.ObtenerMenuUsuario(IdUsuario);
        }

        public List<Menu> ObtenerMenuGeneral()
        {
            return AD.ObtenerMenuGeneral();
        }

        public List<Usuario> ObtenerColaboradoresActivos()
        {
            return AD.ObtenerColaboradoresActivos();
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            return AD.ObtenerTodosUsuarios();
        }

        public List<Roles> ObtenerRoles()
        {
            return AD.ObtenerRoles();
        }

        public List<Roles> ObtenerTodoLosRoles()
        {
            return AD.ObtenerTodoLosRoles();
        }

        public Roles ObtenerRolXId(int IdRol)
        {
            return AD.ObtenerRolXId(IdRol);
        }

        public List<Servicio> ObtenerTodosLosServicios()
        {
            return AD.ObtenerTodosLosServicios();
        }

        public List<Usuario> ObtenerTodosLosColaboradores()
        {
            return AD.ObtenerTodosLosColaboradores();
        }

        public Usuario ObtenerColaboradoresXId (int Id)
        {
            return AD.ObtenerColaboradoresXId(Id);
        }

        public List<UnidadMedida> ObtenerMinutosYHoras()
        {
            return AD.ObtenerMinutosYHoras();
        }

        public List<DiasLibresColaboradores> ObtenerTodosLosDias(int IdColaborador)
        {
            return AD.ObtenerTodosLosDias(IdColaborador);
        }

        public List<Empresa> ObtenerNombresEmpresasActivas()
        {
            return AD.ObtenerNombresEmpresasActivas();
        }

        public Empresa paObtenerEmpresasXId(int Id)
        {
            return AD.paObtenerEmpresasXId(Id);
        }
           

        #endregion

















    }
}
