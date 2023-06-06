using Datos.ConexionOracle;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories
{
    public class OcasionalesRepository : ConnectionManager
    {
        public OcasionalesRepository(string connectionString) : base(connectionString)
        {
        }

        public List<Ocasionales> GetAll()
        {
            List<Ocasionales> ListaOcasionales = new List<Ocasionales>();
            var comando = conexion.CreateCommand();
            comando.CommandText = "SELECT * FROM vista_ocasionales";
            Open();
            OracleDataReader lector = comando.ExecuteReader();
            while (lector.Read())
            {
                ListaOcasionales.Add(MapperToOcasional(lector));
            }
            Close();

            return ListaOcasionales;
        }
        private Ocasionales MapperToOcasional(OracleDataReader dataReader)
        {

            if (!dataReader.HasRows) return null;
            Ocasionales ocasionales = new Ocasionales()
            {
                Id_ocasional = Convert.ToInt32(dataReader["id_ocasional"]),
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
                Cargos_Ocasionales = new Cargos_ocasionales()
                {
                    Cargo_tiempo = dataReader["cargo_tiempo"].ToString(),
                    Salario_cargo = Convert.ToDouble(dataReader["salario_cargo"]),
                },
                Recibos = new Recibos()
                {
                    Nomina = Convert.ToDouble(dataReader["nomina"]),
                }
            };

            return ocasionales;
        }

        public string InsertarDocenteOcasional(Ocasionales ocasionales)
        {
            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "insertarDocenteOcasional";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = ocasionales.Nombre;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = ocasionales.Correo;
                comando.Parameters.Add("p_telefono", OracleType.VarChar).Value = ocasionales.Telefono;
                comando.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = ocasionales.Fecha_nacimiento;
                comando.Parameters.Add("p_id_postgrado", OracleType.Int32).Value = ocasionales.Postgrados.Id_postgrado;
                comando.Parameters.Add("p_id_semillero", OracleType.Int32).Value = ocasionales.Grupos.Id_semillero;
                comando.Parameters.Add("p_id_cargo_ocasional", OracleType.Int32).Value = ocasionales.Cargos_Ocasionales.Id_cargo_ocasional;

                Open();
                comando.ExecuteNonQuery();
                Close();
            }
            return "Docente Ocasional insertado correctamente";
        }

        public string ActualizarDocenteOcasional(Ocasionales ocasionales)
        {
            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "actualizarDocenteOcasional";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_id_ocasional", OracleType.Int32).Value = ocasionales.Id_ocasional;
                comando.Parameters.Add("p_nombre_docente", OracleType.VarChar).Value = ocasionales.Nombre;
                comando.Parameters.Add("p_correo", OracleType.VarChar).Value = ocasionales.Correo;
                comando.Parameters.Add("p_telefono", OracleType.VarChar).Value = ocasionales.Telefono;
                comando.Parameters.Add("p_fecha_nacimiento", OracleType.DateTime).Value = ocasionales.Fecha_nacimiento;
                comando.Parameters.Add("p_id_postgrado", OracleType.Int32).Value = ocasionales.Postgrados.Id_postgrado;
                comando.Parameters.Add("p_id_semillero", OracleType.Int32).Value = ocasionales.Grupos.Id_semillero;
                comando.Parameters.Add("p_id_cargo_ocasional", OracleType.Int32).Value = ocasionales.Cargos_Ocasionales.Id_cargo_ocasional;

                Open();
                comando.ExecuteNonQuery();
                Close();
            }
            return "Docente Ocasional actualizado correctamente";
        }

        //public string EliminarDocenteOcasional(Ocasionales ocasionales)
        //{

        //}
    }
}
