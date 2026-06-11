using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemEventCorp.Clases
{
    internal class Certificado
    {
        public int IdCertificado { get; set; }
        public string CodigoCertificado { get; set; }
        public int IdInscripcion { get; set; }
        public decimal HorasReconocidas { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string Estado { get; set; }
        public string RutaArchivo { get; set; }
        public string Observacion { get; set; }
    }
}
