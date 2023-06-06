using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentación
{
    public static class ConfigConnection
    {
        public static string conexionstring = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
    }
}
