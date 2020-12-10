﻿
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

        public bool InsertarDatosServicios(Servicio servicio, int IdEmpresa)
        {
            return AD.InsertarDatosServicios(servicio, IdEmpresa);
        }

        public int AsignarServiciosXColaborador(Usuario UsuarioXServicio)
        {
            return AD.AsignarServiciosXColaborador(UsuarioXServicio);
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

        public int InsertarHorarioEmpresa(HorarioEmpresa horarioEmpresa, int IdEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)
        {
            return AD.InsertarHorarioEmpresa(horarioEmpresa, IdEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves,EstadoViernes,EstadoSabado,EstadoDomingo);
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

        public bool DesactivarActivarServicioXColaborador(int Id, bool Estado)
        {
            return AD.DesactivarActivarServicioXColaborador(Id, Estado);
        }

        public bool ActualizarHorarioEmpresa(HorarioEmpresa horarioEmpresa, int IdEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)
        {
            return AD.ActualizarHorarioEmpresa(horarioEmpresa, IdEmpresa, EstadoLunes, EstadoMartes, EstadoMiercoles, EstadoJueves, EstadoViernes, EstadoSabado, EstadoDomingo);
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

        public bool EliminarServiciosXColaborador(int Id)
        {
            return AD.EliminarServiciosXColaborador(Id);
        }

        #endregion


        #region SELECTS
        public List<Servicio> ObtenerServiciosActivos(int IdEmpresa)
        {
            return AD.ObtenerServiciosActivos(IdEmpresa);
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

        public List<Usuario> ObtenerColaboradoresActivos(int IdEmpresa)
        {
            return AD.ObtenerColaboradoresActivos(IdEmpresa);
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

        public List<Servicio> ObtenerTodosLosServicios(int IdEmpresa)
        {
            return AD.ObtenerTodosLosServicios(IdEmpresa);
        }

        public List<Usuario> ObtenerTodosLosColaboradores(int IdEmpresa)
        {
            return AD.ObtenerTodosLosColaboradores(IdEmpresa);
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

        public List<Usuario> ObtenerServiciosXColaborador(int IdEmpresa)
        {
            return AD.ObtenerServiciosXColaborador(IdEmpresa);
        }

        public List<Usuario> ObtenerServiciosXColaboradorXId(int IdColaborador)
        {
            return AD.ObtenerServiciosXColaboradorXId(IdColaborador);
        }

        public int ValidarCorreoElectronico(int Id, string CorreoElectronico)
        {
            return AD.ValidarCorreoElectronico(Id, CorreoElectronico);
        }
        public HorarioEmpresa ObtenerHorarioEmpresa(int IdEmpresa)
        {
            return AD.ObtenerHorarioEmpresa(IdEmpresa);
        }

       


        #endregion

















    }
}
