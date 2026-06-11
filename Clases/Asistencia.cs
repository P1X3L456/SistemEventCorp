using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int IdInscripcion { get; set; }
        public int? IdConferencia { get; set; }
        public DateTime FechaAsistencia { get; set; }
        public TimeSpan? HoraLlegada { get; set; }
        public string Estado { get; set; }
        public int? AtendidoPor { get; set; }
        public string Observacion { get; set; }
    }
}
