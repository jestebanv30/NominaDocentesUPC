using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Recibos
    {
        public int Id_recibo { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public double Nomina { get; set; }
        public Docentes Docentes { get; set; }
    }
}
