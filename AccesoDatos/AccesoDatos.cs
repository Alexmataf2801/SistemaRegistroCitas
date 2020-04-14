
using Entidades;
using Entidades.ClasesEntidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                Login login = new Login();
                login.IdUsuario = Convert.ToInt32(IdUsuario.Value.ToString());
                login.Identificacion = usuario.Identificacion;
                login.Contrasena = utilidades.ObtenerClaveTemporal();

                if (Convert.ToInt32(IdUsuario.Value.ToString()) > 0)
                {
                    if (InsertarLogin(login))
                    {
                        Resp = Convert.ToInt32(Respuesta.Value.ToString());
                    }
                }
                else {
                    Resp = Convert.ToInt32(Respuesta.Value.ToString());
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

        public bool InsertarEvento (Evento evento)
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

                foreach (var item in info )
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
                         
            catch(Exception ex)
            {

            }

            return ListaServcios;

        }

    }
}
