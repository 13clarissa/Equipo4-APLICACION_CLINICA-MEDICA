using Clinica_Medica.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisServicios
{
    public partial class EditarServicios
    {
        [Inject] IServiciosService serviciosService { get; set; }

        private Servicio serv = new Servicio();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }
        [Parameter] public string Codigo { get; set; }

        string imgUrl = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                serv = await serviciosService.GetPorCodigo(Convert.ToInt32(Codigo));
            }
        }

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
            if (string.IsNullOrEmpty(serv.Descripcion))
            {
                return;
            }

            bool edito = await serviciosService.Actualizar(serv);

            if (edito)
            {
                await Swal.FireAsync("Advertencia", "Servicio guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Servicios");
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se pudo guardar el servicio", SweetAlertIcon.Error);
            }
        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Servicios");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar el registro?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await serviciosService.Eliminar(Convert.ToInt32(Codigo));

                if (elimino)
                {
                    await Swal.FireAsync("Eliminado", "Servicio Eliminado", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Servicios");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo Eliminar el producto", SweetAlertIcon.Error);
                }
            }
        }
    }

}
