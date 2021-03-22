using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Bitacora
    {

        public int Id { get; set; }
        public string Clase { get; set; }
        public string Metodo { get; set; }
        public string Error { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
