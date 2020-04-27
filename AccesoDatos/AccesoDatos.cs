﻿
using Entidades;
using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace AccesoDatos
{
    public class AccesoDatos
    {
        BDSistemaRegistroCitasEntities entities = new BDSistemaRegistroCitasEntities();

        public void InsertarUsuario(Usuario usuario, ref int Resp)
        {
            Utilidades utilidades = new Utilidades();
            ObjectParameter IdUsuario;
            ObjectParameter Respuesta;
            try
            {
                IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                Respuesta = new ObjectParameter("Respuesta", typeof(int));
                var info = entities.paInsertarUsuario(usuario.Nombre,
                                                      usuario.PrimerApellido,
                                                      usuario.SegundoApellido,
                                                      usuario.Identificacion,
                                                      usuario.CorreoElectronico,
                                                      usuario.Telefono,
                                                      usuario.Genero,
                                                      IdUsuario,
                                                      Respuesta);

                if (!string.IsNullOrEmpty(Respuesta.Value.ToString()))
                {
                    switch (Respuesta.Value.ToString())
                    {
                        case "1":
                            Login login = new Login();
                            login.IdUsuario = Convert.ToInt32(IdUsuario.Value.ToString());
                            login.Identificacion = usuario.Identificacion;
                            login.Contrasena = utilidades.ObtenerClaveTemporal();

                            if (InsertarLogin(login))
                            {
                                Resp = Convert.ToInt32(Respuesta.Value.ToString());
                                utilidades.EnviarCorreo(login.Contrasena, usuario.CorreoElectronico);
                            }

                            break;

                        default:

                            Resp = Convert.ToInt32(Respuesta.Value.ToString());

                            break;
                    }
                    
                }
                else
                {
                    Resp = 0;
                }


            }
            catch (Exception ex)
            {
                Resp = 0;
            }

        }

        public bool InsertarLogin(Login login)
        {
            bool Correcto = false;
            try
            {
                entities.paInsertarLogin(login.IdUsuario, login.Identificacion, login.Contrasena);
                Correcto = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;


        }

        public bool InsertarEvento(Evento evento)
        {
            bool Respuesta = true;
            try
            {
                entities.paInsertarEvento(evento.IdUsuario, evento.IdServicio, evento.Estado, evento.UsuarioCreacion, evento.HorarioInicial, evento.HoraFinal);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;

        }

        public List<Servicio> ObtenerServicios()

        {
            List<Servicio> ListaServcios = new List<Servicio>();
            try
            {

                var info = entities.paObtenerServiciosActivos();

                foreach (var item in info)
                {
                    Servicio servicio = new Servicio();

                    servicio.Id = item.Id;
                    servicio.Nombre = item.Nombre;
                    servicio.Descripcion = item.Descripcion;
                    servicio.TiempoEstimado = item.TiempoEstimado;
                    servicio.TipoUnidad = item.TipoUnidad;

                    ListaServcios.Add(servicio);
                }
            }

            catch (Exception ex)
            {

            }

            return ListaServcios;

        }

        public Usuario Validarlogin(Login login)
        {

            bool respuesta = false;
            ObjectParameter EsCorrecto;
            Usuario usuario = new Usuario();

            try
            {
                EsCorrecto = new ObjectParameter("EsCorrecto", typeof(bool));
                entities.paValidarLogin(login.Identificacion, login.Contrasena, EsCorrecto);
                respuesta = Convert.ToBoolean(EsCorrecto.Value.ToString());

                if (respuesta)
                {

                    usuario = ObtenerUsuario(login.Identificacion);
                }

            }
            catch (Exception ex)
            {

            }

            return usuario;
        }

        public Usuario ObtenerUsuario(string Identificacion)
        {

            Usuario usuario = new Usuario();
            try
            {

                var Info = entities.paObtenerUsuario(Identificacion);

                foreach (var item in Info)
                {

                    usuario.Id = item.Id;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.Identificacion = item.Identificacion;
                    usuario.IdPerfil = item.IdPerfil;
                    usuario.CorreoElectronico = item.CorreroElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Genero = item.Genero;

                }

            }
            catch (Exception ex)
            {

            }

            return usuario;
        }

        public Servicio ServicioXId(int IdServicio)

        {
            Servicio servicio = new Servicio();
            try
            {
                var info = entities.paObtenerServicioXId(IdServicio);


                foreach (var item in info)
                {
                    servicio.Id = item.Id;
                    servicio.Nombre = item.Nombre;
                    servicio.Descripcion = item.Descripcion;
                    servicio.TiempoEstimado = item.TiempoEstimado;
                    servicio.TipoUnidad = item.TipoUnidad;
                    servicio.UnidadMedida = item.UnidadMedida;
                    servicio.Estado = item.Estado;
                }

            }
            catch (Exception ex)
            {

            }
            return servicio;

        }

        public List<Colaboradores> ObtenerColaboradoresActivos()
        {
            List<Colaboradores> ListaColaboradores = new List<Colaboradores>();
            try
            {
                var info = entities.paObtenerColaboradoresActivos();

                foreach(var item in info)
                {
                    Colaboradores colaboradores = new Colaboradores();

                    colaboradores.Id = item.Id;
                    colaboradores.Nombre = item.Nombre;
                    colaboradores.PrimerApellido = item.PrimerApellido;
                    colaboradores.SegundoApellido = item.SegundoApellido;
                    colaboradores.Identificacion = item.Identificacion;
                    colaboradores.CorreoElectronico = item.CorreoElectronico;
                    colaboradores.Telefono = item.Telefono;
                    colaboradores.FotoPerfil = item.FotoPerfil;
                    colaboradores.Estado = item.Estado;

                    ListaColaboradores.Add(colaboradores);
                }

            }
            catch (Exception ex)
            {

            }
            return ListaColaboradores;
        }

        public bool InsertarColaboradores (Colaboradores colaboradores)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarColaboradores(colaboradores.Nombre, colaboradores.PrimerApellido, colaboradores.SegundoApellido, colaboradores.Identificacion,
                colaboradores.CorreoElectronico, colaboradores.Telefono, colaboradores.FotoPerfil, colaboradores.IdPerfil, colaboradores.Estado, colaboradores.UsuarioCreacion);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;

        }

        public bool InsertarRoles(Roles roles)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarRoles(roles.Nombre, roles.Descripcion, roles.Estado, roles.UsuarioCreacion);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;
        }

        public bool InsertarServicios(Servicio servicio)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarServicios(servicio.Nombre, servicio.Descripcion, servicio.TiempoEstimado, servicio.TipoUnidad, servicio.Estado, servicio.UsuarioCreacion);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;
        }

        public bool InsertarUnidadMedida(UnidadMedida unidadMedida)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarUnidadMedida(unidadMedida.Nombre, unidadMedida.Descripcion, unidadMedida.Estado, unidadMedida.UsuarioCreacion);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;
        }
    }
}
