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
    internal class metodosReporte
    {
        public DataTable obtenerResumenEventos()
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_reporte_resumen_eventos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable obtenerParticipantesPorEvento(Evento evento)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_reporte_participantes_evento", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_evento", evento.IdEvento);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable obtenerCertificadosPendientes()
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_reporte_certificados_pendientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
