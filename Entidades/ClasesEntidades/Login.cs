using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Login
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public int IdUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Contrasena { get; set; }
        public bool Temporal { get; set; }
        public bool Estado { get; set; }
        public DateTime FehaCreacion { get; set; }
        public int UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

    }
}
