﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDSistemaRegistroCitasEntities : DbContext
    {
        public BDSistemaRegistroCitasEntities()
            : base("name=BDSistemaRegistroCitasEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int paInsertarEvento(Nullable<int> idUsuario, Nullable<int> idServicio, Nullable<bool> estado, string usuarioCreacion, Nullable<System.DateTime> horarioInicial, Nullable<System.DateTime> horaFinal)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idServicioParameter = idServicio.HasValue ?
                new ObjectParameter("IdServicio", idServicio) :
                new ObjectParameter("IdServicio", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            var horarioInicialParameter = horarioInicial.HasValue ?
                new ObjectParameter("HorarioInicial", horarioInicial) :
                new ObjectParameter("HorarioInicial", typeof(System.DateTime));
    
            var horaFinalParameter = horaFinal.HasValue ?
                new ObjectParameter("HoraFinal", horaFinal) :
                new ObjectParameter("HoraFinal", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarEvento", idUsuarioParameter, idServicioParameter, estadoParameter, usuarioCreacionParameter, horarioInicialParameter, horaFinalParameter);
        }
    
        public virtual ObjectResult<paObtenerServiciosActivos_Result> paObtenerServiciosActivos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerServiciosActivos_Result>("paObtenerServiciosActivos");
        }
    
        public virtual ObjectResult<paObtenerServicioXId_Result> paObtenerServicioXId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerServicioXId_Result>("paObtenerServicioXId", idParameter);
        }
    
        public virtual int paInsertarEmpresa(string nombre, Nullable<int> telefono, string logo, string correoElectronico, Nullable<bool> estado, string direccion, string usuarioCreacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var logoParameter = logo != null ?
                new ObjectParameter("Logo", logo) :
                new ObjectParameter("Logo", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarEmpresa", nombreParameter, telefonoParameter, logoParameter, correoElectronicoParameter, estadoParameter, direccionParameter, usuarioCreacionParameter);
        }
    
        public virtual int PaInsertarRoles(string nombre, string descripcion, Nullable<bool> estado, string usuarioCreacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaInsertarRoles", nombreParameter, descripcionParameter, estadoParameter, usuarioCreacionParameter);
        }
    
        public virtual int PaInsertarServicios(string nombre, string descripcion, Nullable<int> tiempoEstimado, Nullable<int> tipoUnidad, Nullable<bool> estado, string usuarioCreacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var tiempoEstimadoParameter = tiempoEstimado.HasValue ?
                new ObjectParameter("TiempoEstimado", tiempoEstimado) :
                new ObjectParameter("TiempoEstimado", typeof(int));
    
            var tipoUnidadParameter = tipoUnidad.HasValue ?
                new ObjectParameter("TipoUnidad", tipoUnidad) :
                new ObjectParameter("TipoUnidad", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaInsertarServicios", nombreParameter, descripcionParameter, tiempoEstimadoParameter, tipoUnidadParameter, estadoParameter, usuarioCreacionParameter);
        }
    
        public virtual int PaInsertarUnidadMedida(string nombre, string descripcion, Nullable<bool> estado, string usuarioCreacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaInsertarUnidadMedida", nombreParameter, descripcionParameter, estadoParameter, usuarioCreacionParameter);
        }
    
        public virtual int paValidarLogin(string correoElectronico, string contrasena, ObjectParameter esCorrecto)
        {
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paValidarLogin", correoElectronicoParameter, contrasenaParameter, esCorrecto);
        }
    
        public virtual int paInsertarLogin(Nullable<int> idUsuario, string correoElectronico, string contrasena)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var contrasenaParameter = contrasena != null ?
                new ObjectParameter("Contrasena", contrasena) :
                new ObjectParameter("Contrasena", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarLogin", idUsuarioParameter, correoElectronicoParameter, contrasenaParameter);
        }
    
        public virtual ObjectResult<paObtenerMenuXUsuario_Result> paObtenerMenuXUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerMenuXUsuario_Result>("paObtenerMenuXUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<PaObtenerColaboradoresActivos_Result> PaObtenerColaboradoresActivos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaObtenerColaboradoresActivos_Result>("PaObtenerColaboradoresActivos");
        }
    
        public virtual ObjectResult<paObtenerMenuGeneral_Result> paObtenerMenuGeneral()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerMenuGeneral_Result>("paObtenerMenuGeneral");
        }
    
        public virtual int paInsertarPermisosXUsuario(Nullable<int> idUsuario, Nullable<int> idMenu)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idMenuParameter = idMenu.HasValue ?
                new ObjectParameter("IdMenu", idMenu) :
                new ObjectParameter("IdMenu", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarPermisosXUsuario", idUsuarioParameter, idMenuParameter);
        }
    
        public virtual ObjectResult<paObtenerUsuariosActivos_Result> paObtenerUsuariosActivos()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerUsuariosActivos_Result>("paObtenerUsuariosActivos");
        }
    
        public virtual int paEliminarPermisosUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paEliminarPermisosUsuario", idUsuarioParameter);
        }
    
        public virtual int paInsertarUsuario(string nombre, string primerApellido, string segundoApellido, string identificacion, string correoElectronico, Nullable<int> telefono, Nullable<bool> genero, Nullable<int> idRol, ObjectParameter idUsuario, ObjectParameter respuesta)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var generoParameter = genero.HasValue ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(bool));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paInsertarUsuario", nombreParameter, primerApellidoParameter, segundoApellidoParameter, identificacionParameter, correoElectronicoParameter, telefonoParameter, generoParameter, idRolParameter, idUsuario, respuesta);
        }
    
        public virtual ObjectResult<paObtenerUsuario_Result> paObtenerUsuario(string correoElectronico)
        {
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerUsuario_Result>("paObtenerUsuario", correoElectronicoParameter);
        }
    
        public virtual int PaInsertarDatosServicios(string nombre, string descripcion, Nullable<int> tiempoEstimado, Nullable<int> tipoUnidad, Nullable<bool> estado, string usuarioCreacion)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var tiempoEstimadoParameter = tiempoEstimado.HasValue ?
                new ObjectParameter("TiempoEstimado", tiempoEstimado) :
                new ObjectParameter("TiempoEstimado", typeof(int));
    
            var tipoUnidadParameter = tipoUnidad.HasValue ?
                new ObjectParameter("TipoUnidad", tipoUnidad) :
                new ObjectParameter("TipoUnidad", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            var usuarioCreacionParameter = usuarioCreacion != null ?
                new ObjectParameter("UsuarioCreacion", usuarioCreacion) :
                new ObjectParameter("UsuarioCreacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaInsertarDatosServicios", nombreParameter, descripcionParameter, tiempoEstimadoParameter, tipoUnidadParameter, estadoParameter, usuarioCreacionParameter);
        }
    
        public virtual ObjectResult<PaObtenerRoles_Result> PaObtenerRoles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PaObtenerRoles_Result>("PaObtenerRoles");
        }
    
        public virtual ObjectResult<paObtenerTodosLosRoles_Result> paObtenerTodosLosRoles()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTodosLosRoles_Result>("paObtenerTodosLosRoles");
        }
    
        public virtual int paDesactivarActivarRol(Nullable<int> idRol, Nullable<bool> estado)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paDesactivarActivarRol", idRolParameter, estadoParameter);
        }
    
        public virtual int paElimminarRol(Nullable<int> idRol)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paElimminarRol", idRolParameter);
        }
    
        public virtual ObjectResult<paObtenerRolXId_Result> paObtenerRolXId(Nullable<int> idRol)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerRolXId_Result>("paObtenerRolXId", idRolParameter);
        }
    
        public virtual int paActualizarRol(Nullable<int> idRol, string nombre, string descripcion, string usuarioUltimaModificacion)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var usuarioUltimaModificacionParameter = usuarioUltimaModificacion != null ?
                new ObjectParameter("UsuarioUltimaModificacion", usuarioUltimaModificacion) :
                new ObjectParameter("UsuarioUltimaModificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paActualizarRol", idRolParameter, nombreParameter, descripcionParameter, usuarioUltimaModificacionParameter);
        }
    
        public virtual int paActualizarServicios(Nullable<int> id, string nombre, string descripcion, Nullable<int> tiempoEstimado, Nullable<int> tipoUnidad, string usuarioUltimaModificacion)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var tiempoEstimadoParameter = tiempoEstimado.HasValue ?
                new ObjectParameter("TiempoEstimado", tiempoEstimado) :
                new ObjectParameter("TiempoEstimado", typeof(int));
    
            var tipoUnidadParameter = tipoUnidad.HasValue ?
                new ObjectParameter("TipoUnidad", tipoUnidad) :
                new ObjectParameter("TipoUnidad", typeof(int));
    
            var usuarioUltimaModificacionParameter = usuarioUltimaModificacion != null ?
                new ObjectParameter("UsuarioUltimaModificacion", usuarioUltimaModificacion) :
                new ObjectParameter("UsuarioUltimaModificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paActualizarServicios", idParameter, nombreParameter, descripcionParameter, tiempoEstimadoParameter, tipoUnidadParameter, usuarioUltimaModificacionParameter);
        }
    
        public virtual int paDesactivarActivarServicios(Nullable<int> id, Nullable<bool> estado)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paDesactivarActivarServicios", idParameter, estadoParameter);
        }
    
        public virtual int paElimminarServicios(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paElimminarServicios", idParameter);
        }
    
        public virtual int paDesactivarActivarColaboradores(Nullable<int> id, Nullable<bool> estado)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paDesactivarActivarColaboradores", idParameter, estadoParameter);
        }
    
        public virtual ObjectResult<paObtenerColaboradoresXId_Result> paObtenerColaboradoresXId(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerColaboradoresXId_Result>("paObtenerColaboradoresXId", idParameter);
        }
    
        public virtual int paEliminarColaboradores(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paEliminarColaboradores", idParameter);
        }
    
        public virtual ObjectResult<paObtenerMinutosYHoras_Result> paObtenerMinutosYHoras()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerMinutosYHoras_Result>("paObtenerMinutosYHoras");
        }
    
        public virtual int PaInsertarDatosColaborador(string nombre, string primerApellido, string segundoApellido, string identificacion, string correoElectronico, Nullable<int> telefono, Nullable<bool> genero, Nullable<int> idRol, ObjectParameter idUsuario, ObjectParameter respuesta)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var generoParameter = genero.HasValue ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(bool));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PaInsertarDatosColaborador", nombreParameter, primerApellidoParameter, segundoApellidoParameter, identificacionParameter, correoElectronicoParameter, telefonoParameter, generoParameter, idRolParameter, idUsuario, respuesta);
        }
    
        public virtual int paActualizarColaboradores(Nullable<int> id, string identificacion, string nombre, string primerApellido, string segundoApellido, string correoElectronico, Nullable<int> telefono, Nullable<bool> genero, Nullable<int> idRol, string usuarioUltimaModificacion)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var identificacionParameter = identificacion != null ?
                new ObjectParameter("Identificacion", identificacion) :
                new ObjectParameter("Identificacion", typeof(string));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var primerApellidoParameter = primerApellido != null ?
                new ObjectParameter("PrimerApellido", primerApellido) :
                new ObjectParameter("PrimerApellido", typeof(string));
    
            var segundoApellidoParameter = segundoApellido != null ?
                new ObjectParameter("SegundoApellido", segundoApellido) :
                new ObjectParameter("SegundoApellido", typeof(string));
    
            var correoElectronicoParameter = correoElectronico != null ?
                new ObjectParameter("CorreoElectronico", correoElectronico) :
                new ObjectParameter("CorreoElectronico", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var generoParameter = genero.HasValue ?
                new ObjectParameter("Genero", genero) :
                new ObjectParameter("Genero", typeof(bool));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var usuarioUltimaModificacionParameter = usuarioUltimaModificacion != null ?
                new ObjectParameter("UsuarioUltimaModificacion", usuarioUltimaModificacion) :
                new ObjectParameter("UsuarioUltimaModificacion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("paActualizarColaboradores", idParameter, identificacionParameter, nombreParameter, primerApellidoParameter, segundoApellidoParameter, correoElectronicoParameter, telefonoParameter, generoParameter, idRolParameter, usuarioUltimaModificacionParameter);
        }
    
        public virtual ObjectResult<paObtenerTodosLosServicios_Result> paObtenerTodosLosServicios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTodosLosServicios_Result>("paObtenerTodosLosServicios");
        }
    
        public virtual ObjectResult<paObtenerTodosLosColaboradores_Result> paObtenerTodosLosColaboradores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<paObtenerTodosLosColaboradores_Result>("paObtenerTodosLosColaboradores");
        }
    }
}
