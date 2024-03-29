﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Login
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string ContrasenaActual { get; set; }
        public string NuevaContrasena { get; set; }
        public string ConfirmaContrasena { get; set; }
        public bool Temporal { get; set; }
        public bool Estado { get; set; }
        public DateTime FehaCreacion { get; set; }
        public int UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }

    }
}
