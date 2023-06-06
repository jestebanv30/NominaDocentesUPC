using Datos.ConexionOracle;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class CargosOcasionalesRepository : ConnectionManager
    {
        public CargosOcasionalesRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Cargos_ocasionales> GettAll()
        {
            List<Cargos_ocasionales> ListaCargos_Ocasionales = new List<Cargos_ocasionales>();

            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM cargos_ocasionales";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaCargos_Ocasionales.Add(MapperToCargos_Ocasionales(lector));
            }
            Close();

            return ListaCargos_Ocasionales;
        }
        private Cargos_ocasionales MapperToCargos_Ocasionales(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Cargos_ocasionales cargos_Ocasionales = new Cargos_ocasionales();
            cargos_Ocasionales.Id_cargo_ocasional = dataReader.GetInt32(0);
            cargos_Ocasionales.Cargo_tiempo = dataReader.GetString(1);
            cargos_Ocasionales.Salario_cargo = dataReader.GetDouble(2);

            return cargos_Ocasionales;
        }
    }
}
