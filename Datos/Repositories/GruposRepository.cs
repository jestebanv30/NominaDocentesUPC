using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data.SqlClient;
using System.Threading;
using Datos.ConexionOracle;

namespace Datos.Repositories
{
    public class GruposRepository : ConnectionManager
    {
        public GruposRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Grupos> GettAll()
        {
            List<Grupos> Listagrupos = new List<Grupos>();
            
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM grupos";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                Listagrupos.Add(MapperToGrupos(lector));
            }
            Close();

            return Listagrupos;
        }
        private Grupos MapperToGrupos(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Grupos grupo = new Grupos();
            grupo.Id_semillero = dataReader.GetInt32(0);
            grupo.Nombre_semillero = dataReader.GetString(1);
            grupo.Valor_semillero = dataReader.GetDouble(2);

            return grupo;
        }
    }
}
