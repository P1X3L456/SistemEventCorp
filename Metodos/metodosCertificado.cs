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
    internal class metodosCertificado
    {
        public DataTable generarCertificado(Certificado certificado)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_generar_certificado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_codigo_certificado", certificado.CodigoCertificado);
                cmd.Parameters.AddWithValue("p_id_inscripcion", certificado.IdInscripcion);
                cmd.Parameters.AddWithValue("p_horas_reconocidas", certificado.HorasReconocidas);
                cmd.Parameters.AddWithValue("p_fecha_emision", (object)certificado.FechaEmision ?? DBNull.Value);
                cmd.Parameters.AddWithValue("p_ruta_archivo", certificado.RutaArchivo);
                cmd.Parameters.AddWithValue("p_observacion", certificado.Observacion);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }

        public DataTable cambiarEstadoCertificado(Certificado certificado)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_cambiar_estado_certificado", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_certificado", certificado.IdCertificado);
                cmd.Parameters.AddWithValue("p_estado", certificado.Estado);
                cmd.Parameters.AddWithValue("p_observacion", certificado.Observacion);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
