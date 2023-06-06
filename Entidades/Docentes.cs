using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Docentes
    {
        public int Id_docente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public Postgrados Postgrados { get; set; } 
        public Grupos Grupos { get; set; }
        public Recibos Recibos { get; set; }
    }
}
