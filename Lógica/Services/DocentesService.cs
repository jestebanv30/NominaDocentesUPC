using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class DocentesService
    {
        DocentesRepository DocentesRepository;

        public DocentesService(string conexion)
        {
            DocentesRepository = new DocentesRepository(conexion);
        }

        public List<Docentes> GetAll()
        {
            return DocentesRepository.GetAll();
        }

        public List<Docentes> GetAllFiltro(string filtro)
        {
            List<Docentes> lista = new List<Docentes>();
            foreach (var item in DocentesRepository.GetAll())
            {
                if (item.Nombre.Contains(filtro) || item.Telefono.Contains(filtro) || item.Postgrados.Nombre_postgrado.Contains(filtro)
                    || item.Grupos.Nombre_semillero.Contains(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
