
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
            
         return  AD.InsertarEvento(evento);
        }

    }
}
