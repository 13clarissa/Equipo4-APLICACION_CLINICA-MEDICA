using Clinica_Medica.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
namespace Clinica_Medica.Pages.MisPacientes
{
    public partial class Pacientes
    {
		[Inject] private IPacienteService pacienteService { get; set; }

		private IEnumerable<Paciente> listaPaciente { get; set; }

		protected override async Task OnInitializedAsync()
		{
			listaPaciente = await pacienteService.GetLista();
		}
	}
}
