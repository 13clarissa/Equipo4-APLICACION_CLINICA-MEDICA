using Clinica_Medica.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Modelos;

namespace Clinica_Medica.Pages.MisServicios
{
    public partial class NuevoServicios
    {
        [Inject] IServiciosService serviciosService { get; set; }

        private Servicio serv = new Servicio();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }

        string imgUrl = string.Empty;

        private async Task SeleccionarIMagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            serv.Imagen = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(serv.Codigo.ToString()) || string.IsNullOrEmpty(serv.Descripcion))
            {
                return;
            }
            serv.FechaCreacion = DateTime.Now;
			Servicio servicioExistente = new Servicio();

			servicioExistente = await serviciosService.GetPorCodigo(serv.Codigo);

			if (servicioExistente != null)
			{
				if (!string.IsNullOrEmpty(servicioExistente.Codigo.ToString()))
				{
					await Swal.FireAsync("Advertencia", "Ya existe un producto con este código", SweetAlertIcon.Warning);
					return;
				}
			}

			bool inserto = await serviciosService.Nuevo(serv);

            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "Servicio guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Servicios");
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se pudo guardar el Servicio", SweetAlertIcon.Error);
            }
        }
        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Servicios");
        }
    }
}
