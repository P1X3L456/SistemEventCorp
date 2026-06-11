using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace SistemEventCorp.Metodos
{
    internal class Conexion
    {
        private string db;
        private string servidor;
        private string usuario;
        private string contrasena;
        private string ssl;

        public Conexion()
        {
            this.db = "eventcorp_db";
            this.servidor = "localhost";
            this.usuario = "root";
            this.contrasena = "SOFTWARE"; 
            this.ssl = "None";
        }

        public MySqlConnection obtenerConexion()
        {
            MySqlConnection cadena = new MySqlConnection();

            try
            {
                cadena.ConnectionString =
                    "Database=" + db +
                    "; Data Source=" + servidor +
                    "; User Id=" + usuario +
                    "; Password=" + contrasena +
                    "; SSL Mode=" + ssl + ";";
            }
            catch (Exception ex)
            {
                cadena = null;
                throw ex;
            }

            return cadena;
        }
    }
}
