using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
  public  class HorarioEmpresa
    {
        public int IdEmpresa { get; set; }
        public TimeSpan InicioLunes { get; set; }
        public TimeSpan FinalLunes { get; set; }
        public bool EstadoLunes { get; set; }
        public TimeSpan InicioMartes{ get; set; }
        public TimeSpan FinalMartes { get; set; }
        public bool EstadoMartes { get; set; }
        public TimeSpan InicioMiercoles { get; set; }
        public TimeSpan FinalMiercoles { get; set; }
        public bool EstadoMiercoles { get; set; }
        public TimeSpan InicioJueves { get; set; }
        public TimeSpan FinalJueves { get; set; }
        public bool EstadoJueves { get; set; }
        public TimeSpan InicioViernes { get; set; }
        public TimeSpan FinalViernes { get; set; }
        public bool EstadoViernes { get; set; }
        public TimeSpan InicioSabado { get; set; }
        public TimeSpan FinalSabado { get; set; }
        public bool EstadoSabado { get; set; }
        public TimeSpan InicioDomingo { get; set; }
        public TimeSpan FinalDomingo { get; set; }
        public bool EstadoDomingo { get; set; }

    }
}
