using Clinica_Medica.Interfaces;
using Clinica_Medica.Service;
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
        [Inject] private IServiciosService serviciosService { get; set; }
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


        private async void BuscarServicio()
        {
            servicio = await serviciosService.GetPorCodigo(Convert.ToInt32(codigoServicio));
        }

        protected async Task AgregarServicio(MouseEventArgs args)
        {
            if (args.Detail != 0)
            {
                if (servicio != null)
                {
                    DetalleFactura detalle = new DetalleFactura();
                    detalle.Servicio = servicio.Descripcion;
                    detalle.CodigoServicio = servicio.Codigo;
                    detalle.Cantidad = Convert.ToInt32(cantidad);
                    detalle.Precio = servicio.Precio;
                    detalle.Total = servicio.Precio * Convert.ToInt32(cantidad);
                    listaDetalleFactura.Add(detalle);

                    servicio.Codigo = 0;
                    servicio.Descripcion = string.Empty;
                    servicio.Precio = 0;
                    servicio.CitasDisponibles = 0;
                    cantidad = 0;
                    codigoServicio = "0";

                    factura.SubTotal = factura.SubTotal + detalle.Total;
                    factura.ISV = factura.SubTotal * 0.15M;
                    factura.Total = factura.SubTotal + factura.ISV - factura.Descuento;
                }

            }

        }
                
        	protected async Task Guardar()
            {
			factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;
			int idFactura = await facturaService.Nueva(factura);
			if (idFactura != 0)
			{
				foreach (var item in listaDetalleFactura)
				{
                    item.IdFactura = idFactura;
					await detalleFacturaService.Nuevo(item);
				}
				await Swal.FireAsync("Felicidades", "Factura guardada con exito", SweetAlertIcon.Success);
			}
			else
			{
				await Swal.FireAsync("Error", "No se pudo guardar la factura", SweetAlertIcon.Error);
			}

            }



    }
}
