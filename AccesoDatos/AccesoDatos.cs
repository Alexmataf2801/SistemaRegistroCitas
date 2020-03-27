using Entidades;
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


        public bool InsertarUsuario(Usuario usuario) {
            bool Correcto = false;
            ObjectParameter IdUsuario;

            try
            {
                IdUsuario = new ObjectParameter("IdUsuario", typeof(int));
                var info = entities.paInsertarUsuario(usuario.Nombre,
                                                      usuario.PrimerApellido,
                                                      usuario.SegundoApellido,
                                                      usuario.Identificacion,
                                                      usuario.CorreoElectronico,
                                                      usuario.Telefono,
                                                      usuario.Genero,
                                                      IdUsuario);
            }
            catch (Exception)
            {

                throw;
            }

           


            return Correcto;
        }

    }
}
