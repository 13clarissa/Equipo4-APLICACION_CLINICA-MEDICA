using Clinica_Medica.Interfaces;
using Clinica_Medica.Service;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisPacientes
{
    public partial class EditarPaciente
    {
		[Inject] private IPacienteService pacienteService { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		private Paciente pac = new Paciente();

		[Inject] SweetAlertService Swal { get; set; }

		[Parameter] public string IdentidadPaciente { get; set; }

		protected override async Task OnInitializedAsync()
		{
			if (!string.IsNullOrEmpty(IdentidadPaciente))
			{
				pac = await pacienteService.GetPorCodigo(IdentidadPaciente);
			}
		}

		protected async void Guardar()
		{
			if (string.IsNullOrEmpty(pac.IdentidadPaciente) || string.IsNullOrEmpty(pac.Nombre)
				|| string.IsNullOrEmpty(pac.Telefono) || string.IsNullOrEmpty(pac.Direccion) || 
				string.IsNullOrEmpty(Convert.ToDateTime(pac.FechaNacimiento).ToString()) || 
				string.IsNullOrEmpty(pac.EstadoCivil) || pac.EstadoCivil == "Seleccionar" || string.IsNullOrEmpty(pac.Genero) || pac.Genero == "Seleccionar")
			{
				return;
			}

			bool edito = await pacienteService.Actualizar(pac);

			if (edito)
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

		protected async void Eliminar()
		{
			bool elimino = false;

			SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
			{
				Title = "¿Seguro que desea eliminar este registro?",
				Icon = SweetAlertIcon.Question,
				ShowCancelButton = true,
				ConfirmButtonText = "Aceptar",
				CancelButtonText = "Cancelar"
			});

			if (!string.IsNullOrEmpty(result.Value))
			{
				elimino = await pacienteService.Eliminar(IdentidadPaciente);

				if (elimino)
				{
					await Swal.FireAsync("Eliminado", "Registro Paciente Eliminado", SweetAlertIcon.Success);
					navigationManager.NavigateTo("/Usuarios");
				}
				else
				{
					await Swal.FireAsync("Error", "No se pudo Eliminar el registro del paciente", SweetAlertIcon.Error);
				}
			}
		}
	}
}
