using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Catedraticos : Docentes
    {
        public int Id_catedratico { get; set; }
        public int Num_horas { get; set; }
        public double Valor_hora { get; set; }
        public int Salario_bruto { get; set; }

    }
}
