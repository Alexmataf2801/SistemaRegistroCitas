using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Menu
    {
        public string IdMenu { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public string IdPadre { get; set; }
        public string IdHijo { get; set; }
        public string Nivel { get; set; }
        public string Orden { get; set; }
        public string IsPadre { get; set; }
        public string Url { get; set; }
    }
}
