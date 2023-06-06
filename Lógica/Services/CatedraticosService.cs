using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class CatedraticosService
    {
        CatedraticosRepository catedraticosRepository;

        public CatedraticosService(string conexion)
        {
            catedraticosRepository = new CatedraticosRepository(conexion);
        }

        public List<Catedraticos> GetAll()
        {
            return catedraticosRepository.GetAll();
        }

        public string Insert(Catedraticos catedraticos)
        {
            return catedraticosRepository.InsertarDocenteCatedratico(catedraticos);
        }

        public string Update(Catedraticos catedraticos)
        {
            return catedraticosRepository.ActualizarDocenteCatedratico(catedraticos);
        }

        public List<Catedraticos> GetAllFiltro(string filtro)
        {
            List<Catedraticos> lista = new List<Catedraticos>();
            foreach (var item in catedraticosRepository.GetAll())
            {
                if (item.Nombre.Contains(filtro) || item.Telefono.Contains(filtro) || item.Postgrados.Nombre_postgrado.Contains(filtro)
                    || item.Grupos.Nombre_semillero.Contains(filtro) || item.Num_horas.ToString().Contains(filtro) || item.Valor_hora.ToString().Contains(filtro))
                {
                    lista.Add(item);
                }
            }
            return lista;
        }
    }
}
