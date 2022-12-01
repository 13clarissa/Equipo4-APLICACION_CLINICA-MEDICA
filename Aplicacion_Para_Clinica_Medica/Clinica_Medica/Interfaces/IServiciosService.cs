using Modelos;

namespace Clinica_Medica.Interfaces
{
    public interface IServiciosService
    {
        Task<bool> Nuevo(Servicio servicio);
        Task<bool> Actualizar(Servicio servicio);
        Task<bool> Eliminar(int codigo);
        Task<IEnumerable<Servicio>> GetLista();
        Task<Servicio> GetPorCodigo(int codigo);
    }
}
