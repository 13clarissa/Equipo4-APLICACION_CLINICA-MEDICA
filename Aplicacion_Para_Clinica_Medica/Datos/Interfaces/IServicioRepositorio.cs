using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IServicioRepositorio
    {
        Task<bool> Nuevo(Servicio servicio);
        Task<bool> Actualizar(Servicio servicio);
        Task<bool> Eliminar(int codigo);
        Task<IEnumerable<Servicio>> GetLista();
        Task<Servicio> GetPorCodigo(int codigo);
    }
}
