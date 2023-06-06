using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class PostgradosService
    {
        PostgradosRepository postgradosRepository;

        public PostgradosService(string conexion)
        {
            postgradosRepository = new PostgradosRepository(conexion);
        }

        public List<Postgrados> GetAll()
        {
            return postgradosRepository.GettAll();
        }
    }
}
