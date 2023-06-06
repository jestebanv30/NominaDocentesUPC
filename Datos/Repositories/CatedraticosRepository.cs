using Datos.ConexionOracle;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class CatedraticosRepository : ConnectionManager
    {
        public CatedraticosRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Catedraticos> GetAll()
        {
            List<Catedraticos> ListaCatedraticos = new List<Catedraticos>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM vista_catedraticos";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaCatedraticos.Add(MapperToCatedraticos(lector));
            }
            Close();

            return ListaCatedraticos;
        }
        private Catedraticos MapperToCatedraticos(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Catedraticos catedraticos = new Catedraticos()
            {
                Id_catedratico = Convert.ToInt32(dataReader["id_catedratico"]),
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
                Num_horas = Convert.ToInt32(dataReader["num_horas"]),
                Valor_hora = Convert.ToInt32(dataReader["valor_horas"]),
                Salario_bruto = Convert.ToInt32(dataReader["salario_bruto"]),
                Recibos = new Recibos()
                {
                    Nomina = Convert.ToDouble(dataReader["nomina"]),
                }
            };

            return catedraticos;
        }

        public string InsertarDocenteCatedratico(Catedraticos catedraticos)
        {
            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "insertarDocenteCatedratico";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = catedraticos.Nombre;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = catedraticos.Correo;
                comando.Parameters.Add("p_telefono", OracleType.VarChar).Value = catedraticos.Telefono;
                comando.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = catedraticos.Fecha_nacimiento;
                comando.Parameters.Add("p_id_postgrado", OracleType.Int32).Value = catedraticos.Postgrados.Id_postgrado;
                comando.Parameters.Add("p_id_semillero", OracleType.Int32).Value = catedraticos.Grupos.Id_semillero;
                comando.Parameters.Add("p_num_horas", OracleType.Int32).Value = catedraticos.Num_horas;
                comando.Parameters.Add("p_valor_horas", OracleType.Int32).Value = catedraticos.Valor_hora;

                Open();
                comando.ExecuteNonQuery();
                Close();
            }
            return "Docente Catedrático insertado correctamente";
        }

        public string ActualizarDocenteCatedratico(Catedraticos catedraticos)
        {
            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "actualizarDocenteCatedratico";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_id_catedratico", OracleType.Int32).Value = catedraticos.Id_catedratico;
                comando.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = catedraticos.Nombre;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = catedraticos.Correo;
                comando.Parameters.Add("p_telefono", OracleType.VarChar).Value = catedraticos.Telefono;
                comando.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = catedraticos.Fecha_nacimiento;
                comando.Parameters.Add("p_id_postgrado", OracleType.Int32).Value = catedraticos.Postgrados.Id_postgrado;
                comando.Parameters.Add("p_id_semillero", OracleType.Int32).Value = catedraticos.Grupos.Id_semillero;
                comando.Parameters.Add("p_num_horas", OracleType.Int32).Value = catedraticos.Num_horas;
                comando.Parameters.Add("p_valor_horas", OracleType.Int32).Value = catedraticos.Valor_hora;

                Open();
                comando.ExecuteNonQuery();
                Close();
            }
            return "Docente Catedrático actualizado correctamente";
        }
    }
}
