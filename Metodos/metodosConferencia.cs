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
    internal class metodosConferencia
    {
        public int crearConferencia(Conferencia conferencia)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_crear_conferencia", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_evento", conferencia.IdEvento);
                cmd.Parameters.AddWithValue("p_titulo", conferencia.Titulo);
                cmd.Parameters.AddWithValue("p_descripcion", conferencia.Descripcion);
                cmd.Parameters.AddWithValue("p_ponente", conferencia.Ponente);
                cmd.Parameters.AddWithValue("p_sala", conferencia.Sala);
                cmd.Parameters.AddWithValue("p_fecha", conferencia.Fecha);
                cmd.Parameters.AddWithValue("p_hora_inicio", conferencia.HoraInicio);
                cmd.Parameters.AddWithValue("p_hora_fin", (object)conferencia.HoraFin ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_cupo", conferencia.Cupo);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable listarAgendaEvento(Evento evento)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_listar_agenda_evento", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_evento", evento.IdEvento);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
