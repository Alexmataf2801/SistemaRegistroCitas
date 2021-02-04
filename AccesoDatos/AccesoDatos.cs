
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


        #region INSERTS

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
                                                      usuario.IdRol,
                                                      IdUsuario,
                                                      Respuesta);

                

                if (!string.IsNullOrEmpty(Respuesta.Value.ToString()))
                {
                    switch (Respuesta.Value.ToString())
                    {
                        case "1":
                            Login login = new Login();
                            login.IdUsuario = Convert.ToInt32(IdUsuario.Value.ToString());
                            login.CorreoElectronico = usuario.CorreoElectronico;
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
                entities.paInsertarLogin(login.IdUsuario, login.CorreoElectronico, login.Contrasena);
                Correcto = true;
            }
            catch (Exception ex)
            {

                throw;
            }

            return Correcto;


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

        public bool InsertarDatosServicios(Servicio servicio, int IdEmpresa)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarServicios(servicio.Nombre, servicio.Descripcion, servicio.TiempoEstimado, servicio.TipoUnidad,servicio.UsuarioCreacion,IdEmpresa);
                Respuesta = true;
            }
            catch (Exception ex)
            {
                Respuesta = false;
            }

            return Respuesta;
        }

        public int AsignarServiciosXColaborador(Usuario UsuarioXServicio)
        {
            ObjectParameter RespuestaCorrecta;
           
            int Respuesta = 0;
            try
            {
                RespuestaCorrecta = new ObjectParameter("RespuestaCorrecta", typeof(int));
                entities.PaAsignarServiciosXColaborador(UsuarioXServicio.Id,UsuarioXServicio.IdServicio,RespuestaCorrecta);
                Respuesta = Convert.ToInt32(RespuestaCorrecta.Value.ToString());
            }
            catch (Exception ex)
            {
                Respuesta = 3;
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

        public List<Usuario> ObtenerColaboradoresActivos(int IdEmpresa)
        {
            List<Usuario> ListaColaboradores = new List<Usuario>();

            try
            {
                var info = entities.PaObtenerColaboradoresActivos(IdEmpresa);

                foreach (var item in info)
                {
                    Usuario Colaborador = new Usuario();

                    Colaborador.Id = item.Id;
                    Colaborador.Nombre = item.Nombre;

                    ListaColaboradores.Add(Colaborador);

                }

            }
            catch (Exception ex)
            {

            }


            return ListaColaboradores;

        }

        public List<Menu> ObtenerMenuGeneral()
        {
            List<Menu> ListaMenu = new List<Menu>();

            try
            {
                var info = entities.paObtenerMenuGeneral();

                foreach (var item in info)
                {
                    Menu menu = new Menu();
                    menu.IdMenu = item.IdMenu.ToString();
                    menu.Nombre = item.Nombre;
                    menu.Icono = item.Icono;
                    menu.IdPadre = item.IdPadre;
                    menu.IdHijo = item.IdHijo;
                    menu.Nivel = item.Nivel;
                    menu.Orden = item.Orden;
                    menu.IsPadre = item.IsPadre.ToString();
                    menu.Url = item.Url;


                    ListaMenu.Add(menu);

                }

            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaMenu;
        }

        public List<Usuario> ObtenerTodosUsuarios()
        {
            List<Usuario> ListaUsuarios = new List<Usuario>();

            try
            {
                var info = entities.paObtenerUsuariosActivos();

                foreach (var item in info)
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = item.Id;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.Identificacion = item.Identificacion;
                    usuario.CorreoElectronico = item.CorreoElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Genero = item.Genero;
                    usuario.FotoPerfil = item.FotoPerfil;
                    usuario.IdRol = item.IdRol;
                    usuario.NombreCompleto = item.Nombre + " " + item.PrimerApellido + " " + item.SegundoApellido;



                    ListaUsuarios.Add(usuario);

                }

            }
            catch (Exception ex)
            {

            }


            return ListaUsuarios;

        }

        public void InsertarDatosColaborador(Usuario usuario, ref int Resp)
        {
            Utilidades utilidades = new Utilidades();
            ObjectParameter IdUsuario;
            ObjectParameter Respuesta;
            ObjectParameter RespuestaUsuarioXEmpresa;
            try
            {
                IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                Respuesta = new ObjectParameter("Respuesta", typeof(int));
                RespuestaUsuarioXEmpresa = new ObjectParameter("RespuestaUsuarioXEmpresa", typeof(int));
                var info = entities.PaInsertarDatosColaborador(usuario.Nombre,
                                                      usuario.PrimerApellido,
                                                      usuario.SegundoApellido,
                                                      usuario.Identificacion,
                                                      usuario.CorreoElectronico,
                                                      usuario.Telefono,
                                                      usuario.Genero,
                                                      usuario.IdRol,
                                                      IdUsuario,
                                                      Respuesta);

              

                if (!string.IsNullOrEmpty(Respuesta.Value.ToString()))
                {
                    switch (Respuesta.Value.ToString())
                    {
                        case "1":

                        var infoUsuarioXEmpresa = entities.PaInsertarUsuarioXEmpresa(
                                                    Convert.ToInt32(IdUsuario.Value.ToString()),
                                                     usuario.IdRol,
                                                     usuario.IdEmpresa,
                                                     RespuestaUsuarioXEmpresa);

                            Login login = new Login();
                            login.IdUsuario = Convert.ToInt32(IdUsuario.Value.ToString());
                            login.CorreoElectronico = usuario.CorreoElectronico;
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

        public bool InsertarPermisosXUsuario(int IdUsuario, List<int> ListaPermisos)
        {
            bool Correcto = false;
            try
            {
                //Primero se borran todos los permisos
                EliminarPermisosXUsuario(IdUsuario);

                // Luego se vuelve a insertar todos los permisos, es mas facil hacerlo de esta forma
                // para no tener que comparar luego permiso por permiso para ver si se habilitan o no
                for (int i = 0; i < ListaPermisos.Count; i++)
                {
                    entities.paInsertarPermisosXUsuario(IdUsuario, ListaPermisos[i]);

                }
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;

            }

            return Correcto;
        }

        public int InsertarHorarioEmpresa(HorarioEmpresa horarioEmpresa, int IdEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)
        {
            ObjectParameter RespuestaCorrecta;
            int Respuesta = 0;
            try
            {
                RespuestaCorrecta = new ObjectParameter("RespuestaCorrecta", typeof(int));
                entities.PaInsertarHorarioEmpresa(IdEmpresa, horarioEmpresa.InicioLunes,horarioEmpresa.FinalLunes,EstadoLunes,horarioEmpresa.InicioMartes,horarioEmpresa.FinalMartes,EstadoMartes,
                   horarioEmpresa.InicioMiercoles,horarioEmpresa.FinalMiercoles,EstadoMiercoles,horarioEmpresa.InicioJueves,horarioEmpresa.FinalJueves,EstadoJueves,
                   horarioEmpresa.InicioViernes,horarioEmpresa.FinalViernes,EstadoViernes,horarioEmpresa.InicioSabado,horarioEmpresa.FinalSabado,EstadoSabado,
                   horarioEmpresa.InicioDomingo,horarioEmpresa.FinalDomingo,EstadoDomingo,RespuestaCorrecta);
                Respuesta = Convert.ToInt32(RespuestaCorrecta.Value.ToString());
            }
            catch (Exception ex)
            {
                Respuesta = 2;

            }

            return Respuesta;
                        

        }

        public int InsertarEventos(Eventos eventos, int IdEmpresa, int IdRol)
        {
            ObjectParameter RespuestaCorrecta;
            int Respuesta = 0;
            try
            {
                RespuestaCorrecta = new ObjectParameter("RespuestaCorrecta", typeof(int));
                entities.PaInsertarEventos(IdEmpresa, eventos.IdUsuario, eventos.IdUsuarioCrecion, IdRol, eventos.IdServicio,eventos.Nombre, eventos.TipoUnidadEvento,
                    eventos.HorarioInicial, eventos.HoraFinal, eventos.UsuarioCreacion,RespuestaCorrecta);
                Respuesta = Convert.ToInt32(RespuestaCorrecta.Value.ToString());
            }
            catch (Exception ex)
            {

                Respuesta = 3;
            }

            return Respuesta;


        }

        #endregion


        #region UPDATES

        public bool ActualizarRol(Roles rol)
        {
            bool Correcto = false;

            try
            {
                entities.paActualizarRol(rol.Id, rol.Nombre, rol.Descripcion, rol.UsuarioUltimaModificacion);
                Correcto = true;
            }
            catch (Exception ex)
            {
                Correcto = false;
            }


            return Correcto;
        }
        public bool DesactivarActivarRol(int IdRol, bool Estado)
        {

            bool SeActualizo = false;

            try
            {
                entities.paDesactivarActivarRol(IdRol, Estado);
                SeActualizo = true;
            }
            catch (Exception ex)
            {
                SeActualizo = false;
            }


            return SeActualizo;

        }

        public bool ActualizarServicios(Servicio servicio)
        {
            bool Correcto = false;

            try
            {
                entities.paActualizarServicios(servicio.Id, servicio.Nombre, servicio.Descripcion, servicio.TiempoEstimado, servicio.TipoUnidad, servicio.UsuarioUltimaModificacion);
                Correcto = true;
            }
            catch (Exception ex)
            {
                Correcto = false;
            }

            return Correcto;
        }
        public bool DesactivarActivarServicios(int Id, bool Estado)
        {
            bool SeActualizo = false;

            try
            {
                entities.paDesactivarActivarServicios(Id, Estado);
                SeActualizo = true;
            }
            catch (Exception ex)
            {
                SeActualizo = false;
            }

            return SeActualizo;
        }

        public bool ActualizarColaboradores(Usuario usuario)
        {
            bool Correcto = false;
           
            try
            {
                
                entities.paActualizarColaboradores(usuario.Id, usuario.Identificacion, usuario.Nombre, usuario.PrimerApellido, usuario.SegundoApellido, usuario.CorreoElectronico, usuario.Telefono,
                    usuario.Genero, usuario.IdRol, usuario.UsuarioUltimaModificacion);
                Correcto = true;
            }
            catch (Exception ex)
            {
                Correcto = false;
            }

            return Correcto;
        }
        public bool DesactivarActivarColaboradores(int Id, bool Estado)
        {
            bool SeActualizo = false;

            try
            {
                entities.paDesactivarActivarColaboradores(Id, Estado);
                SeActualizo = true;
            }
            catch (Exception ex)
            {
                SeActualizo = false;
            }

            return SeActualizo;
        }

        public bool DesactivarActivarDiasLibres(bool Lunes, bool Martes, bool Miercoles, bool Jueves, bool Viernes, bool Sabado, bool Domingo, int IdColaborador)
        {
            bool SeActualizo = false;

            try
            {
                entities.paDesactivarActivarDiasLibres(Lunes, Martes, Miercoles, Jueves, Viernes, Sabado, Domingo, IdColaborador);
                SeActualizo = true;
            }
            catch (Exception ex)
            {
                SeActualizo = false;
            }

            return SeActualizo;
        }

        public bool DesactivarActivarServicioXColaborador(int Id, bool Estado)
        {
            bool SeActualizo = false;

            try
            {
                entities.paDesactivarActivarServicioXColaborador(Id, Estado);
                SeActualizo = true;
            }
            catch (Exception ex)
            {
                SeActualizo = false;
            }

            return SeActualizo;
        }

       public bool ActualizarHorarioEmpresa(HorarioEmpresa horarioEmpresa, int IdEmpresa, bool EstadoLunes, bool EstadoMartes, bool EstadoMiercoles, bool EstadoJueves, bool EstadoViernes, bool EstadoSabado, bool EstadoDomingo)
        {
            bool Correcto = false;
            try
            {
                entities.paActualizarHorarioEmpresa(horarioEmpresa.InicioLunes, horarioEmpresa.FinalLunes, EstadoLunes, horarioEmpresa.InicioMartes, horarioEmpresa.FinalMartes,EstadoMartes,
                    horarioEmpresa.InicioMiercoles, horarioEmpresa.FinalMiercoles,EstadoMiercoles, horarioEmpresa.InicioJueves, horarioEmpresa.FinalJueves,EstadoJueves,
                    horarioEmpresa.InicioViernes, horarioEmpresa.FinalViernes, EstadoViernes, horarioEmpresa.InicioSabado, horarioEmpresa.FinalSabado,EstadoSabado,
                    horarioEmpresa.InicioDomingo, horarioEmpresa.FinalDomingo, EstadoDomingo, IdEmpresa);
                Correcto = true;

            }
            catch (Exception ex)
            {
                Correcto = false;
            }

            return Correcto;

        }


        #endregion


        #region DELETES

        public void EliminarPermisosXUsuario(int IdUsuario)
        {
            try
            {
                entities.paEliminarPermisosUsuario(IdUsuario);
            }
            catch (Exception ex)
            {

            }
        }

        public bool EliminarRol(int IdRol)
        {

            bool SeElimino = false;

            try
            {
                entities.paElimminarRol(IdRol);
                SeElimino = true;
            }
            catch (Exception)
            {
                SeElimino = false;
            }


            return SeElimino;

        }

        public bool EliminarServicios(int Id)
        {
            bool SeElimino = false;

            try
            {
                entities.paElimminarServicios(Id);
                SeElimino = true;
            }
            catch (Exception)
            {
                SeElimino = false;
            }

            return SeElimino;
        }

        public bool EliminarColaboradores(int Id)
        {
            bool SeElimino = false;

            try
            {
                entities.paEliminarColaboradores(Id);
                SeElimino = true;
            }
            catch (Exception ex)
            {
                SeElimino = false;
            }

            return SeElimino;
        }

        public bool EliminarServiciosXColaborador(int Id)
        {
            bool SeElimino = false;

            try
            {
                entities.paEliminarServiciosXColaborador(Id);
                SeElimino = true;
            }
            catch (Exception)
            {
                SeElimino = false;
            }

            return SeElimino;
        }

        public bool EliminarEventos(int Id)
        {
            bool SeElimino = false;

            try
            {
                entities.paEliminarEventos(Id);
                SeElimino = true;
            }
            catch (Exception)
            {
                SeElimino = false;
            }

            return SeElimino;
        }

        #endregion


        #region SELECTS

        public List<Servicio> ObtenerServiciosActivos(int IdEmpresa)

        {
            List<Servicio> ListaServcios = new List<Servicio>();
            try
            {

                var info = entities.paObtenerServiciosActivos(IdEmpresa);

                foreach (var item in info)
                {
                    Servicio servicio = new Servicio();

                    servicio.Id = item.Id;
                    servicio.Nombre = item.Nombre;
                   

                    ListaServcios.Add(servicio);
                }
            }

            catch (Exception ex)
            {

            }

            return ListaServcios;

        }

        public Usuario Validarlogin(Login login, int IdEmpresa)
        {

            bool respuesta = false;
            ObjectParameter EsCorrecto;
            Usuario usuario = new Usuario();

            try
            {
                EsCorrecto = new ObjectParameter("EsCorrecto", typeof(bool));
                entities.paValidarLogin(login.CorreoElectronico, login.Contrasena, IdEmpresa, EsCorrecto);
                respuesta = Convert.ToBoolean(EsCorrecto.Value.ToString());

                if (respuesta)
                {

                    usuario = ObtenerUsuario(login.CorreoElectronico);
                }

            }
            catch (Exception ex)
            {

            }

            return usuario;
        }

        public Usuario ObtenerUsuario(string CorreroElectronico)
        {

            Usuario usuario = new Usuario();
            try
            {

                var Info = entities.paObtenerUsuario(CorreroElectronico);

                foreach (var item in Info)
                {
                    
                    usuario.Id = item.Id;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.Identificacion = item.Identificacion;
                    usuario.CorreoElectronico = item.CorreoElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Genero = item.Genero;
                    usuario.NombreCompleto = item.Nombre + " " + item.PrimerApellido + " " + item.SegundoApellido;
                    usuario.IdRol = item.IdRol;

                    if (item.IdRol != 4) {

                        usuario.IdEmpresa = item.IdEmpresa;
                    }

                    

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

        public List<Menu> ObtenerMenuUsuario(int IdUsuario)
        {
            List<Menu> ListaMenu = new List<Menu>();

            try
            {
                var info = entities.paObtenerMenuXUsuario(IdUsuario);

                foreach (var item in info)
                {
                    Menu menu = new Menu();
                    menu.IdMenu = item.IdMenu.ToString();
                    menu.Nombre = item.Nombre;
                    menu.Icono = item.Icono;
                    menu.IdPadre = item.IdPadre;
                    menu.IdHijo = item.IdHijo;
                    menu.Nivel = item.Nivel;
                    menu.Orden = item.Orden;
                    menu.IsPadre = item.IsPadre.ToString();
                    menu.Url = item.Url;


                    ListaMenu.Add(menu);

                }

            }
            catch (Exception ex)
            {

                throw;
            }


            return ListaMenu;
        }

        public List<Roles> ObtenerRoles()
        {
            List<Roles> ListaRoles = new List<Roles>();
            try
            {

                var info = entities.PaObtenerRoles();

                foreach (var item in info)
                {
                    Roles roles = new Roles();

                    roles.Id = item.Id;
                    roles.Nombre = item.Nombre;


                    ListaRoles.Add(roles);
                }
            }

            catch (Exception ex)
            {

            }

            return ListaRoles;

        }

        public List<Roles> ObtenerTodoLosRoles()
        {

            List<Roles> ListaRoles = new List<Roles>();
            try
            {

                var info = entities.paObtenerTodosLosRoles();

                foreach (var item in info)
                {
                    Roles roles = new Roles();


                    roles.Id = item.Id;
                    roles.Nombre = item.Nombre;
                    roles.Descripcion = item.Descripcion;
                    roles.Estado = item.Estado;
                    roles.UsuarioCreacion = item.UsuarioCreacion;
                    roles.FechaCreacion = item.FechaCreacion;
                    roles.UsuarioUltimaModificacion = item.UsuarioUltimaMoficacion;
                    roles.FechaUltimaModificacion = item.FechaUltimaModificacion;


                    ListaRoles.Add(roles);

                }
            }

            catch (Exception ex)
            {

            }

            return ListaRoles;

        }

        public Roles ObtenerRolXId(int IdRol)
        {

            Roles roles = new Roles();

            try
            {
                var Info = entities.paObtenerRolXId(IdRol);

                foreach (var item in Info)
                {
                    roles.Id = item.Id;
                    roles.Nombre = item.Nombre;
                    roles.Descripcion = item.Descripcion;
                    roles.Estado = item.Estado;
                    roles.UsuarioCreacion = item.UsuarioCreacion;
                    roles.FechaCreacion = item.FechaCreacion;
                    roles.UsuarioUltimaModificacion = item.UsuarioUltimaMoficacion;
                    roles.FechaUltimaModificacion = item.FechaUltimaModificacion;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return roles;
        }

        public List<Servicio> ObtenerTodosLosServicios(int IdEmpresa)
        {
            List<Servicio> ListaServicios = new List<Servicio>();
            try
            {
                var info = entities.paObtenerTodosLosServicios(IdEmpresa);

                foreach (var item in info)
                {
                    Servicio servicio = new Servicio();

                    servicio.Id = item.Id;
                    servicio.Nombre = item.Nombre;
                    servicio.Descripcion = item.Descripcion;
                    servicio.TiempoEstimado = item.TiempoEstimado;
                    servicio.TipoUnidad = item.TipoUnidad;
                    servicio.Estado = item.Estado;
                    servicio.UsuarioCreacion = item.UsuarioCreacion;
                    servicio.FechaCreacion = item.FechaCreacion;
                    servicio.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    servicio.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    servicio.NombreUnidadMedida = item.NombreUnidadMedida;

                    ListaServicios.Add(servicio);
                }
            }
            catch (Exception ex)
            {

            }

            return ListaServicios;
        }

        public List<Usuario> ObtenerTodosLosColaboradores(int IdEmpresa)
        {
               List<Usuario> ListaColaboradores = new List<Usuario>();
            try
            {
                var info = entities.paObtenerTodosLosColaboradores(IdEmpresa);

                foreach(var item in info)
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = item.Id;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.Identificacion = item.Identificacion;
                    usuario.CorreoElectronico = item.CorreoElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Genero = item.Genero;
                    usuario.FotoPerfil = item.FotoPerfil;
                    usuario.IdRol = item.IdRol;
                    usuario.Estado = item.Estado;
                    usuario.UsuarioCreacion = item.UsuarioCreacion;
                    usuario.FechaCreacion = item.FechaCreacion;
                    usuario.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    usuario.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    usuario.NombreRol = item.NombreRol;

                    ListaColaboradores.Add(usuario);

                }
            }
            catch(Exception ex)
            {

            }

            return ListaColaboradores;
        }

        public Usuario ObtenerColaboradoresXId( int Id)
        {
            Usuario usuario = new Usuario();

            try
            {
                var info = entities.paObtenerColaboradoresXId(Id);

                foreach (var item in info)
                {
                    usuario.Id = item.Id;
                    usuario.Nombre = item.Nombre;
                    usuario.PrimerApellido = item.PrimerApellido;
                    usuario.SegundoApellido = item.SegundoApellido;
                    usuario.Identificacion = item.Identificacion;
                    usuario.CorreoElectronico = item.CorreoElectronico;
                    usuario.Telefono = item.Telefono;
                    usuario.Genero = item.Genero;
                    usuario.IdRol = item.IdRol;
                    usuario.Estado = item.Estado;
                    usuario.UsuarioCreacion = item.UsuarioCreacion;
                    usuario.FechaCreacion = item.FechaCreacion;
                    usuario.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    usuario.FechaUltimaModificacion = item.FechaUltimaModificacion;
                }
            }
            catch(Exception ex)
            {
                throw;
            }

            return usuario;
        }

        public List<UnidadMedida> ObtenerMinutosYHoras()
        {

            List<UnidadMedida> ListaUnidadMedida = new List<UnidadMedida>();
            try
            {

                var info = entities.paObtenerMinutosYHoras();

                foreach (var item in info)
                {
                    UnidadMedida unidadMedida  = new UnidadMedida();


                    unidadMedida.Id = item.Id;
                    unidadMedida.Nombre = item.Nombre;
                    unidadMedida.Descripcion = item.Descripcion;
                    unidadMedida.UsuarioCreacion = item.UsuarioCreacion;
                    unidadMedida.FechaCreacion = item.FechaCreacion;
                    unidadMedida.UsuarioCreacion = item.UsuarioCreacion;
                    unidadMedida.FechaUltimaModificacion = item.FechaUltimaModificacion;
                    unidadMedida.Estado = item.Estado;


                    ListaUnidadMedida.Add(unidadMedida);

                }
            }

            catch (Exception ex)
            {

            }

            return ListaUnidadMedida;

        }

        public List<DiasLibresColaboradores> ObtenerTodosLosDias(int IdColaborador)
        {
            List<DiasLibresColaboradores> ListadiasLibresColaboradores  = new List<DiasLibresColaboradores>();

            try
            {
                var info = entities.paObtenerTodosLosDias(IdColaborador);

                foreach (var item in info)
                {
                    DiasLibresColaboradores diasLibresColaboradores = new DiasLibresColaboradores();

                    diasLibresColaboradores.IdColaborador = item.IdColaborador;
                    diasLibresColaboradores.Lunes = item.Lunes;
                    diasLibresColaboradores.Martes = item.Martes;
                    diasLibresColaboradores.Miercoles = item.Miercoles;
                    diasLibresColaboradores.Jueves = item.Jueves;
                    diasLibresColaboradores.Viernes = item.Viernes;
                    diasLibresColaboradores.Sabado = item.Sabado;
                    diasLibresColaboradores.Domingo = item.Domingo;

                    ListadiasLibresColaboradores.Add(diasLibresColaboradores);

                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ListadiasLibresColaboradores;
        }

        public List<Empresa> ObtenerNombresEmpresasActivas()

        {
            List<Empresa> ListaEmpresa = new List<Empresa>();
            try
            {

                var info = entities.paObtenerNombresEmpresasActivas();

                foreach (var item in info)
                {
                    Empresa empresa = new Empresa();

                    empresa.Id = item.Id;
                    empresa.Nombre = item.Nombre;
                   

                    ListaEmpresa.Add(empresa);
                }
            }

            catch (Exception ex)
            {

            }

            return ListaEmpresa;

        }

        public Empresa paObtenerEmpresasXId(int Id)
        {
            Empresa empresa = new Empresa();

            try
            {
                var info = entities.paObtenerEmpresasXId(Id);

                foreach (var item in info)
                {
                    empresa.Id = item.Id;
                    empresa.Nombre = item.Nombre;
                    empresa.Telefono = item.Telefono;
                    empresa.Logo = item.Logo;
                    empresa.CorreElectronico = item.CorreoElectronico;
                    empresa.Direccion = item.Direccion;
                    empresa.UsuarioCreacion = item.UsuarioCreacion;
                    empresa.FechaCreacion = item.FechaCreacion;
                    empresa.UsuarioUltimaModificacion = item.UsuarioUltimaModificacion;
                    empresa.FechaUltimaModificacion = item.FechaUltimaModificacion;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return empresa;
        }


        public List<Usuario> ObtenerServiciosXColaborador(int IdEmpresa)
        {
            List<Usuario> ListaServiciosXColaborador = new List<Usuario>();

            try
            {
                var info = entities.paObtenerServiciosXColaborador(IdEmpresa);

                foreach (var item in info)
                {
                    Usuario usuario = new Usuario();

                    usuario.IdServicioXColaborador = item.Id;
                    usuario.Id = item.IdColaborador;
                    usuario.IdServicio = item.IdServicio;
                    usuario.Estado = item.Estado;
                    usuario.Nombre = item.Nombre;
                    usuario.NombreServicio = item.NombreServicio;

                    ListaServiciosXColaborador.Add(usuario);

                }
            }

            catch(Exception ex)
            {

            }
            return ListaServiciosXColaborador;

        }
      
        public List<Usuario> ObtenerServiciosXColaboradorXId(int IdColaborador)
        {
            
            List<Usuario> ListaServiciosXColaboradorXId = new List<Usuario>();

            try
            {
                var info = entities.paObtenerServiciosXColaboradorXId(IdColaborador);

                foreach (var item in info)
                {
                    Usuario usuario = new Usuario();

                    usuario.Id = item.IdColaborador;
                    usuario.IdServicio = item.IdServicio;
                    usuario.NombreServicio = item.NombreServicio;

                    ListaServiciosXColaboradorXId.Add(usuario);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return ListaServiciosXColaboradorXId;
        }

        public int ValidarCorreoElectronico(int Id, string CorreoElectronico)
        {
            int valor = 0;
            ObjectParameter Respuesta;
            
           
            try
            {
                Respuesta = new ObjectParameter("Respuesta", typeof(int));
                entities.PaValidarCorreoElectronico(Id, CorreoElectronico, Respuesta);
                         

                valor = Convert.ToInt32(Respuesta.Value.ToString());
              
            }
            catch (Exception)
            {

                throw;
            }
            return valor;
        }

        public HorarioEmpresa ObtenerHorarioEmpresa(int IdEmpresa)
           
        {
            HorarioEmpresa HorarioEmpresa = new HorarioEmpresa();

            try
            {

                var info = entities.paObtenerHorarioEmpresa(IdEmpresa);

                foreach (var item in info)
                {
                    
                    HorarioEmpresa.InicioLunes = item.InicioLunes;
                    HorarioEmpresa.FinalLunes = item.FinalLunes;
                    HorarioEmpresa.EstadoLunes = item.EstadoLunes;

                    HorarioEmpresa.InicioMartes = item.InicioMartes;
                    HorarioEmpresa.FinalMartes = item.FinalMartes;
                    HorarioEmpresa.EstadoMartes = item.EstadoMartes;

                    HorarioEmpresa.InicioMiercoles = item.InicioMiercoles;
                    HorarioEmpresa.FinalMiercoles = item.FinalMiercoles;
                    HorarioEmpresa.EstadoMiercoles = item.EstadoMiercoles;

                    HorarioEmpresa.InicioJueves = item.InicioJueves;
                    HorarioEmpresa.FinalJueves = item.FinalJueves;
                    HorarioEmpresa.EstadoJueves = item.EstadoJueves;

                    HorarioEmpresa.InicioViernes = item.InicioViernes;
                    HorarioEmpresa.FinalViernes = item.FinalViernes;
                    HorarioEmpresa.EstadoViernes = item.EstadoViernes;

                    HorarioEmpresa.InicioSabado = item.InicioSabado;
                    HorarioEmpresa.FinalSabado = item.FinalSabado;
                    HorarioEmpresa.EstadoSabado = item.EstadoSabado;

                    HorarioEmpresa.InicioDomingo = item.InicioDomingo;
                    HorarioEmpresa.FinalDomingo= item.FinalDomingo;
                    HorarioEmpresa.EstadoDomingo = item.EstadoDomingo;


                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return HorarioEmpresa;

        }


        public List<Eventos> ObtenerTodosLosEventosXIdEmpresa(int IdEmpresa)
        {
            List<Eventos> ListaEventos = new List<Eventos>();
            try
            {
                var info = entities.paObtenerTodosLosEventosXIdEmpresa(IdEmpresa);

                foreach (var item in info)
                {
                    Eventos Eventos = new Eventos();

                    Eventos.Id = item.Id;
                    Eventos.IdUsuario = item.IdUsuario;
                    Eventos.IdUsuarioCrecion = item.IdUsuarioCreador;
                    Eventos.IdServicio = item.IdServicio;
                    Eventos.HorarioInicial = item.HorarioInicial;
                    Eventos.HoraFinal = item.HoraFinal;
                    Eventos.UsuarioCreacion = item.UsuarioCreacion;
                    Eventos.NombreColaborador = item.NombreColaborador;
                    Eventos.NombreServicio = item.NombreServicio;                    

                    ListaEventos.Add(Eventos);
                }
            }
            catch (Exception ex)
            {

            }

            return ListaEventos;
        }


        public List<Eventos> ObtenerTodosLosEventosXIdUsuarioCreador(int IdUsuarioCreador)
        {
            List<Eventos> ListaEventos = new List<Eventos>();
            try
            {
                var info = entities.paObtenerTodosLosEventosXIdUsuarioCreador(IdUsuarioCreador);

                foreach (var item in info)
                {
                    Eventos Eventos = new Eventos();

                    Eventos.Id = item.Id;
                    Eventos.IdUsuario = item.Id;                   
                    Eventos.IdServicio = item.IdServicio;
                    Eventos.HorarioInicial = item.HorarioInicial;
                    Eventos.HoraFinal = item.HoraFinal;
                    Eventos.UsuarioCreacion = item.UsuarioCreacion;
                    Eventos.NombreColaborador = item.NombreColaborador;
                    Eventos.NombreServicio = item.NombreServicio;

                    ListaEventos.Add(Eventos);
                }
            }
            catch (Exception ex)
            {

            }

            return ListaEventos;
        }


        public List<Eventos> ObtenerTodosLosEventosHorasLibresXIdEmpresa(int IdEmpresa)
        {
            List<Eventos> ListaEventos = new List<Eventos>();
            try
            {
                var info = entities.paObtenerTodosLosEventosHorasLibresXIdEmpresa(IdEmpresa);

                foreach (var item in info)
                {
                    Eventos Eventos = new Eventos();

                    Eventos.Id = item.Id;
                    Eventos.IdUsuario = item.IdUsuario;
                    Eventos.IdUsuarioCrecion = item.IdUsuarioCreador;
                    Eventos.IdServicio = item.IdServicio;
                    Eventos.HorarioInicial = item.HorarioInicial;
                    Eventos.HoraFinal = item.HoraFinal;
                    Eventos.UsuarioCreacion = item.UsuarioCreacion;
                    Eventos.NombreColaborador = item.NombreColaborador;
                   

                    ListaEventos.Add(Eventos);
                }
            }
            catch (Exception ex)
            {

            }

            return ListaEventos;
        }


        public List<Eventos> ObtenerTodosLosEventosXIdUsuario(int IdUsuario)
        {
            List<Eventos> ListaEventos = new List<Eventos>();
            try
            {
                var info = entities.paObtenerTodosLosEventosXIdUsuario(IdUsuario);

                foreach (var item in info)
                {
                    Eventos Eventos = new Eventos();

                    Eventos.Id = item.Id;
                    Eventos.IdUsuario = item.IdUsuario;
                    Eventos.IdUsuarioCrecion = item.IdUsuarioCreador;
                    Eventos.IdServicio = item.IdServicio;
                    Eventos.Nombre = item.Nombre;
                    Eventos.TipoUnidadEvento = item.TipoUnidadEvento;
                    Eventos.HorarioInicial = item.HorarioInicial;
                    Eventos.HoraFinal = item.HoraFinal;
                    Eventos.UsuarioCreacion = item.UsuarioCreacion;                
                  

                    ListaEventos.Add(Eventos);
                }
            }
            catch (Exception ex)
            {

            }

            return ListaEventos;
        }



        #endregion








    }
}
    
    
