using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class OcasionalesService
    {
        OcasionalesRepository ocasionalesRepository;

        public OcasionalesService(string conexion)
        {
            ocasionalesRepository = new OcasionalesRepository(conexion);
        }

        public List<Ocasionales> GettAll()
        {
            return ocasionalesRepository.GetAll();
        }

        public string Insert(Ocasionales ocasionales)
        {
            return ocasionalesRepository.InsertarDocenteOcasional(ocasionales);
        }

        public string Update(Ocasionales ocasionales)
        {
            return ocasionalesRepository.ActualizarDocenteOcasional(ocasionales);
        }

        public List<Ocasionales> GetAllFiltro(string filtro)
        {
            List<Ocasionales> lista = new List<Ocasionales>();
            foreach (var item in ocasionalesRepository.GetAll())
            {
                if (item.Nombre.Contains(filtro) || item.Telefono.Contains(filtro) || item.Postgrados.Nombre_postgrado.Contains(filtro)
                    || item.Grupos.Nombre_semillero.Contains(filtro) || item.Cargos_Ocasionales.Cargo_tiempo.Contains(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
