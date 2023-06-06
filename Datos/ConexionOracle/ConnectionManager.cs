using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ConexionOracle
{
    public class ConnectionManager
    {
        protected OracleConnection conexion;

        public ConnectionManager(string connectionString)
        {
            conexion = new OracleConnection(connectionString);
        }
        public void Open()
        {
            conexion.Open();
        }
        public void Close()
        {
            conexion.Close();
        }
    }
}
