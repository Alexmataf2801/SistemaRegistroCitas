using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
   public class Eventos
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public int IdDia { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioCrecion { get; set; }
        public int IdRol { get; set; }
        public int IdServicio { get; set; }
        public int TipoUnidadEvento { get; set; }
        public string HorarioInicial { get; set; }
        public string HoraFinal { get; set; }
        public bool Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public string NombreColaborador { get; set; }
        public string NombreServicio { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

       

    }
}
