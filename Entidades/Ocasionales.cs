using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ocasionales : Docentes
    {
        public int Id_ocasional { get; set; }
        public Cargos_ocasionales Cargos_Ocasionales { get; set; }
    }
}
