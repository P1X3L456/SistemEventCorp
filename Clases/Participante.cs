using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Participante
    {
        public int IdParticipante { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Institucion { get; set; }
        public string Interes { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
    }
}
