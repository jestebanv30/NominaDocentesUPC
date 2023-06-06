using Datos.ConexionOracle;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class DocentesRepository : ConnectionManager
    {
        public DocentesRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Docentes> GetAll()
        {
            List<Docentes> ListaDocentes = new List<Docentes>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM vista_docentes";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaDocentes.Add(MapperToDocente(lector));
            }
            Close();

            return ListaDocentes;
        }
        private Docentes MapperToDocente(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Docentes docente = new Docentes()
            {
                Id_docente = Convert.ToInt32(dataReader["id_docente"]),
                Nombre = dataReader["nombre_docente"].ToString(),
                Correo = dataReader["correo"].ToString(),
                Telefono = dataReader["telefono"].ToString(),
                Fecha_nacimiento = Convert.ToDateTime(dataReader["fecha_nacimiento"]),
                Postgrados = new Postgrados()
                {
                    Nombre_postgrado = dataReader["nombre_postgrado"].ToString(),
                },
                Grupos = new Grupos()
                {
                    Nombre_semillero = dataReader["nombre_semillero"].ToString(),
                },
                Recibos = new Recibos()
                {
                    Nomina = Convert.ToDouble(dataReader["nomina"]),
                }
            };

            return docente;
        }
    }
}