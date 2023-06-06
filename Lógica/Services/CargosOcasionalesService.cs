using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class CargosOcasionalesService
    {
        CargosOcasionalesRepository cargosOcasionalesRepo;

        public CargosOcasionalesService(string conexion)
        {
            cargosOcasionalesRepo = new CargosOcasionalesRepository(conexion);
        }

        public List<Cargos_ocasionales> GetAll()
        {
            return cargosOcasionalesRepo.GettAll();
        }
    }
}
