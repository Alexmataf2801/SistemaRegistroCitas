
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
                entities.paValidarLogin(login.CorreoElectronico, login.Contrasena, EsCorrecto);
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

        public bool InsertarDatosServicios(Servicio servicio)
        {
            bool Respuesta = true;
            try
            {
                entities.PaInsertarDatosServicios(servicio.Nombre, servicio.Descripcion, servicio.TiempoEstimado, servicio.TipoUnidad, servicio.Estado, servicio.UsuarioCreacion);
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

        public void InsertarDatosColaborador(Usuario usuario, ref int Resp)
        {
            Utilidades utilidades = new Utilidades();
            ObjectParameter IdUsuario;
            ObjectParameter Respuesta;
            try
            {
                IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                Respuesta = new ObjectParameter("Respuesta", typeof(int));
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

        public List<Usuario> ObtenerColaboradoresActivos()
        {
            List<Usuario> ListaColaboradores = new List<Usuario>();

            try
            {
                var info = entities.PaObtenerColaboradoresActivos();

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

    }
}
