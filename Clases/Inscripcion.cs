using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Inscripcion
    {
        public int IdInscripcion { get; set; }
        public string CodigoInscripcion { get; set; }
        public int IdEvento { get; set; }
        public int IdParticipante { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
    }
}
