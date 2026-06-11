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
    internal class metodosEvento
    {
        public int crearEvento(Evento evento)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_crear_evento", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_codigo_evento", evento.CodigoEvento);
                cmd.Parameters.AddWithValue("p_nombre", evento.Nombre);
                cmd.Parameters.AddWithValue("p_descripcion", evento.Descripcion);
                cmd.Parameters.AddWithValue("p_fecha_inicio", evento.FechaInicio);
                cmd.Parameters.AddWithValue("p_fecha_fin", (object)evento.FechaFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_hora_inicio", (object)evento.HoraInicio ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_hora_fin", (object)evento.HoraFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_lugar", evento.Lugar);
                cmd.Parameters.AddWithValue("p_modalidad", evento.Modalidad);
                cmd.Parameters.AddWithValue("p_capacidad", evento.Capacidad);
                cmd.Parameters.AddWithValue("p_id_responsable", (object)evento.IdResponsable ?? DBNull.Value);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable cambiarEstadoEvento(Evento evento)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_cambiar_estado_evento", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_evento", evento.IdEvento);
                cmd.Parameters.AddWithValue("p_estado", evento.Estado);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable listarResumenEventos()
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
    }
}
