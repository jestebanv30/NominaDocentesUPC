using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class GruposService
    {
        GruposRepository gruposRepository;

        public GruposService(string conexion)
        {
            gruposRepository = new GruposRepository(conexion);
        }
        public List<Grupos> GetAll()
        {
            return gruposRepository.GettAll();
        }
    }
}
