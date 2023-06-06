using Datos.ConexionOracle;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class PostgradosRepository : ConnectionManager
    {
        public PostgradosRepository(string connectionString) : base(connectionString)
        {
        }
        public List<Postgrados> GettAll()
        {
            List<Postgrados> ListaPostgrados = new List<Postgrados>();

            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM postgrados";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaPostgrados.Add(MapperToPostgrados(lector));
            }
            Close();

            return ListaPostgrados;
        }
        private Postgrados MapperToPostgrados(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Postgrados postgrados = new Postgrados();
            postgrados.Id_postgrado = dataReader.GetInt32(0);
            postgrados.Nombre_postgrado = dataReader.GetString(1);
            postgrados.Valor_postgrado = dataReader.GetDouble(2);

            return postgrados;
        }
    }
}
