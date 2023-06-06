using Datos.ConexionOracle;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos.Repositories
{
    public class RecibosRepository : ConnectionManager
    {
        public RecibosRepository(string connectionString) : base(connectionString)
        {
        }

        public string ActualizarRecibo(Recibos recibos)
        {
            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText = "actualizarRecibo";
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("p_id_docente", OracleType.Int32).Value = recibos.Docentes.Id_docente;
                comando.Parameters.Add("p_fecha", OracleType.DateTime).Value = recibos.Fecha;
                comando.Parameters.Add("p_observaciones", OracleType.VarChar).Value = recibos.Observaciones;

                Open();
                comando.ExecuteNonQuery();
                Close();
            }
            return "Recibo realizado correctamente";
        }

    }
}
