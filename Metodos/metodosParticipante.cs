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
    internal class metodosParticipante
    {
        public int registrarParticipante(Participante participante)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_registrar_participante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_tipo_documento", participante.TipoDocumento);
                cmd.Parameters.AddWithValue("p_numero_documento", participante.NumeroDocumento);
                cmd.Parameters.AddWithValue("p_nombres", participante.Nombres);
                cmd.Parameters.AddWithValue("p_apellidos", participante.Apellidos);
                cmd.Parameters.AddWithValue("p_correo", participante.Correo);
                cmd.Parameters.AddWithValue("p_telefono", participante.Telefono);
                cmd.Parameters.AddWithValue("p_institucion", participante.Institucion);
                cmd.Parameters.AddWithValue("p_interes", participante.Interes);
                cmd.Parameters.AddWithValue("p_observacion", participante.Observacion);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable buscarParticipante(string filtro)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_buscar_participante", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_filtro", filtro);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
