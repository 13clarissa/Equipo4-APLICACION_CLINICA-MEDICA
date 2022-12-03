using Modelos;

namespace Clinica_Medica.Interfaces
{
    public interface IDetalleFacturaService
    {

        Task<bool> Nuevo(DetalleFactura detalleFactura);


    }
}
