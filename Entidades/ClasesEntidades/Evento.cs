using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Evento
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdServicio { get; set; }
        public DateTime HorarioInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public bool Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

    }
}
