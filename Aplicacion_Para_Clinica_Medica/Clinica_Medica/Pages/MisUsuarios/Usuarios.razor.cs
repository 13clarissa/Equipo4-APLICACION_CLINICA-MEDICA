using Clinica_Medica.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisUsuarios
{
    public partial class Usuarios
    {
        [Inject] private IUsuarioService usuarioService { get; set; }

        private IEnumerable<Usuario> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await usuarioService.GetLista();
        }
    }
}
