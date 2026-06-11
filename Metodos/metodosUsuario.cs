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
    internal class metodosUsuario
    {
        public int crearUsuario(Usuario usuario)
        {
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_crear_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_rol", usuario.IdRol);
                cmd.Parameters.AddWithValue("p_nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("p_apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("p_correo", usuario.Correo);
                cmd.Parameters.AddWithValue("p_nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("p_clave", usuario.Clave);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public DataTable actualizarAccesoUsuario(Usuario usuario)
        {
            DataTable tabla = new DataTable();
            Conexion conexion = new Conexion();

            using (MySqlConnection cn = conexion.obtenerConexion())
            {
                cn.Open();

                MySqlCommand cmd = new MySqlCommand("sp_actualizar_acceso_usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("p_id_usuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("p_id_rol", usuario.IdRol);
                cmd.Parameters.AddWithValue("p_estado", usuario.Estado);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
            }

            return tabla;
        }
    }
}
