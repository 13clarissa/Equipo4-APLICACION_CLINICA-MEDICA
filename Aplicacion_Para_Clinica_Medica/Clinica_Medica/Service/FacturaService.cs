using Clinica_Medica.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Clinica_Medica.Service
{
    public class FacturaService : IFacturaService
    {
        private readonly Config _configuracion;
        private IFacturaRepositorio facturaRepositorio;

        public FacturaService(Config config)
        {
            _configuracion = config;
            facturaRepositorio = new FacturaRepositorio(config.CadenaConexion);
        }

        public async Task<int> Nueva(Factura factura)
        {
            return await facturaRepositorio.Nueva(factura);
        }
    }
}
