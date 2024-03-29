﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.ClasesEntidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreServicio { get; set; }
        public string NombreRol { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Identificacion { get; set; }
        public string CorreoElectronico { get; set; }
        public int Telefono { get; set; }
        public bool Genero { get; set; }
        public bool TerminosYCondiciones { get; set; }
        public int IdRol { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPlan { get; set; }
        public int IdServicio { get; set; }
        public int IdServicioXColaborador { get; set; }
        public string FotoPerfil { get; set; }
        public bool Estado { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string UsuarioUltimaModificacion { get; set; }
        public DateTime? FechaUltimaModificacion { get; set; }
        public bool CTemp { get; set; }

    }
}
