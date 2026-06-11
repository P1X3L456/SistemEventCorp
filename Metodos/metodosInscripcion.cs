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
    internal class metodosInscripcion
    {
        public int registrarInscripcion(Inscripcion inscripcion)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_registrar_inscripcion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_codigo_inscripcion", inscripcion.CodigoInscripcion);
                cmd.Parameters.AddWithValue("p_id_evento", inscripcion.IdEvento);
                cmd.Parameters.AddWithValue("p_id_participante", inscripcion.IdParticipante);
                cmd.Parameters.AddWithValue("p_estado", inscripcion.Estado);
                cmd.Parameters.AddWithValue("p_observacion", inscripcion.Observacion);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable cambiarEstadoInscripcion(Inscripcion inscripcion)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_cambiar_estado_inscripcion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_inscripcion", inscripcion.IdInscripcion);
                cmd.Parameters.AddWithValue("p_estado", inscripcion.Estado);
                cmd.Parameters.AddWithValue("p_observacion", inscripcion.Observacion);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    } 
}
