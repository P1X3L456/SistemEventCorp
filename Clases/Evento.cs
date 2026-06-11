using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Evento
    {
        public int IdEvento { get; set; }
        public string CodigoEvento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public string Lugar { get; set; }
        public string Modalidad { get; set; }
        public int Capacidad { get; set; }
        public string Estado { get; set; }
        public int? IdResponsable { get; set; }
    }
}
