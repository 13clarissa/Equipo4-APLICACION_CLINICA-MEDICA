using Clinica_Medica.Interfaces;
using Clinica_Medica.Service;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisPacientes
{
	public partial class NuevoPaciente
	{
		[Inject] private IPacienteService pacienteService { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		private Paciente pac = new Paciente();

		[Inject] SweetAlertService Swal {get; set;}

		protected async void Guardar()
		{
			if (string.IsNullOrEmpty(pac.IdentidadPaciente) || string.IsNullOrEmpty(pac.Nombre)
				|| string.IsNullOrEmpty(pac.Telefono) || string.IsNullOrEmpty(pac.Direccion) ||
				string.IsNullOrEmpty(Convert.ToDateTime(pac.FechaNacimiento).ToString()) ||
				string.IsNullOrEmpty(pac.EstadoCivil) || pac.EstadoCivil == "Seleccionar" || string.IsNullOrEmpty(pac.Genero) || pac.Genero == "Seleccionar")
			{
				return;
			}

			bool inserto = await pacienteService.Nuevo(pac);

			if (inserto)
			{
				await Swal.FireAsync("Felicidades", "Registro del Paciente Guardado", SweetAlertIcon.Success);
			}
			else
			{
				await Swal.FireAsync("Error", "No se pudo guardar el registro del paciente", SweetAlertIcon.Error);
			}

			navigationManager.NavigateTo("/Pacientes");
		}

		protected void Cancelar()
		{
			navigationManager.NavigateTo("/Pacientes");
		}
	}
}
enum EstadoCivil
{
	Seleccionar,
	Soltero,
	Casado,
	Union_Libre
}

enum Genero
{
	Seleccionar,
	Femenino,
	Masculino
}