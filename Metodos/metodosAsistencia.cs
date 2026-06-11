using SistemEventCorp.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
namespace SistemEventCorp.Metodos
{
    internal class metodosAsistencia
    {
        public DataTable marcarAsistencia(Asistencia asistencia)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_marcar_asistencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_inscripcion", asistencia.IdInscripcion);
                cmd.Parameters.AddWithValue("p_id_conferencia", (object)asistencia.IdConferencia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_fecha_asistencia", asistencia.FechaAsistencia);
                cmd.Parameters.AddWithValue("p_hora_llegada", (object)asistencia.HoraLlegada ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_estado", asistencia.Estado);
                cmd.Parameters.AddWithValue("p_atendido_por", (object)asistencia.AtendidoPor ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_observacion", asistencia.Observacion);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
