using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }
    }
}
