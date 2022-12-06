using Clinica_Medica.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Clinica_Medica.Service
{
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private readonly Config _configuracion;
        private IDetalleFacturaRepositorio detalleFacturaRepositorio;

        public DetalleFacturaService(Config config)
        {
            _configuracion = config;
            detalleFacturaRepositorio = new DetalleFacturaRepositorio(config.CadenaConexion);
        }
        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
            return await detalleFacturaRepositorio.Nuevo(detalleFactura);
        }


    }
}
