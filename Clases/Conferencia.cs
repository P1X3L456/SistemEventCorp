using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Conferencia
    {
        public int IdConferencia { get; set; }
        public int IdEvento { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Ponente { get; set; }
        public string Sala { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public int Cupo { get; set; }
        public string Estado { get; set; }
    }
}
