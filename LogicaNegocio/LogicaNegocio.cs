
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

        public void InsertarUsuario(Usuario usuario, ref int Resp)
        {

            AD.InsertarUsuario(usuario, ref Resp);

        }

        public bool InsertarEvento(Evento evento)
        {

            return AD.InsertarEvento(evento);
        }

        public List<Servicio> ObtenerServicios()
        {
            return AD.ObtenerServicios();
        }

        public Usuario Validarlogin(Login login)
        {
            return AD.Validarlogin(login);
        }

        public Servicio ServicioXId( int IdServicio)
        {
            return AD.ServicioXId(IdServicio);
        }


        public bool InsertarRoles(Roles roles)
        {
            return AD.InsertarRoles(roles);
        }

        public bool InsertarServicios(Servicio servicio)
        {
            return AD.InsertarServicios(servicio);
        }

        public bool InsertarUnidadMedida(UnidadMedida unidadMedida)
        {
            return AD.InsertarUnidadMedida(unidadMedida);
        }

        public List<Menu> ObtenerMenuUsuario(int IdUsuario)
        {
            return AD.ObtenerMenuUsuario(IdUsuario);
        }

    }
}
