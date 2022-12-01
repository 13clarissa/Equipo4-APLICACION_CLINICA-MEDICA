using Clinica_Medica.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Clinica_Medica.Service
{
    public class ServiciosService : IServiciosService
    {
        private readonly Config _configuracion;
        private IServicioRepositorio servicioRepositorio;

        public ServiciosService(Config config)
        {
            _configuracion = config;
            servicioRepositorio = new ServicioRepositorio(config.CadenaConexion);
        }

        public async Task<bool> Actualizar(Servicio servicio)
        {
            return await servicioRepositorio.Actualizar(servicio);
        }

        public async Task<bool> Eliminar(int codigo)
        {
            return await servicioRepositorio.Eliminar(codigo);
        }

        public async Task<IEnumerable<Servicio>> GetLista()
        {
            return await servicioRepositorio.GetLista();
        }

        public async Task<Servicio> GetPorCodigo(int codigo)
        {
            return await servicioRepositorio.GetPorCodigo(codigo);
        }

        public async Task<bool> Nuevo(Servicio servicio)
        {
            return await servicioRepositorio.Nuevo(servicio);
        }
    }
}
