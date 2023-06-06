using Datos.Repositories;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lógica.Services
{
    public class RecibosService
    {
        RecibosRepository recibosRepository;

        public RecibosService(string conexion) 
        { 
            recibosRepository = new RecibosRepository(conexion);
        }

        public string Update(Recibos recibos)
        {
            return recibosRepository.ActualizarRecibo(recibos);
        }
    }
}
