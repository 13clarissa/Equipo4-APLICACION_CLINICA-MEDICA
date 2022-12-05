using Clinica_Medica.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Modelos;

namespace Clinica_Medica.Pages.Facturacion
{
    public partial class NuevaFactura
    {
        [Inject] private IFacturaService facturaService { get; set; }
        [Inject] private IDetalleFacturaService detalleFacturaService { get; set; }
        [Inject] private IServiciosService productoService { get; set; }
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
        [Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

        private Factura factura = new Factura();
        private List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();
        private Servicio servicio = new Servicio();

        private int cantidad { get; set; }
        private string codigoServicio { get; set; }

        protected override async Task OnInitializedAsync()
        {
            factura.Fecha = DateTime.Now;
        }

        //************************************* COMENZAR DESDE AQUI ABAJO ***************************************************

        private async void BuscarServicio()
        {
            
        }

        protected async Task AgregarServicio(MouseEventArgs args)
        {

        }

    }
}
