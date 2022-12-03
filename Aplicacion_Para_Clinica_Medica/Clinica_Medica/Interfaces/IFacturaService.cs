using Modelos;

namespace Clinica_Medica.Interfaces
{
    public interface IFacturaService
    {
        Task<int> Nueva(Factura factura);
    }
}
