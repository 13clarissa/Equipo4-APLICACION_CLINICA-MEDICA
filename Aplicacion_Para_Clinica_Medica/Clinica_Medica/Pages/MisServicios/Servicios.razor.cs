using Clinica_Medica.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisServicios
{
    public partial class Servicios
    {
        [Inject] IServiciosService serviciosService { get; set; }

        IEnumerable<Servicio> listaServicio { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaServicio = await serviciosService.GetLista();
        }
    }
}
