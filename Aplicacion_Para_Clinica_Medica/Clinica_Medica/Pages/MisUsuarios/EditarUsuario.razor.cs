using Clinica_Medica.Interfaces;
using Clinica_Medica.Service;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Clinica_Medica.Pages.MisUsuarios
{
	public partial class EditarUsuario
	{
		[Inject] private IUsuarioService usuarioService { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		private Usuario user = new Usuario();

		[Inject] SweetAlertService Swal { get; set; }

		[Parameter] public string Codigo { get; set; }

		protected override async Task OnInitializedAsync()
		{
			if (!string.IsNullOrEmpty(Codigo))
			{
				user = await usuarioService.GetPorCodigo(Codigo);
			}
		}

		protected async void Guardar()
		{
			if (string.IsNullOrEmpty(user.Codigo) || string.IsNullOrEmpty(user.Nombre)
				|| string.IsNullOrEmpty(user.Clave) || string.IsNullOrEmpty(user.Rol) || user.Rol == "Seleccionar")
			{
				return;
			}

			bool edito = await usuarioService.Actualizar(user);

			if (edito)
			{
				await Swal.FireAsync("Felicidades", "Usuario Actualizado", SweetAlertIcon.Success);
			}
			else
			{
				await Swal.FireAsync("Error", "No se pudo Actualizar el usuario", SweetAlertIcon.Error);
			}

			navigationManager.NavigateTo("/Usuarios");
		}

		protected void Cancelar()
		{
			navigationManager.NavigateTo("/Usuarios");
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
				elimino = await usuarioService.Eliminar(Codigo);

				if (elimino)
				{
					await Swal.FireAsync("Eliminado", "Usuario Eliminado", SweetAlertIcon.Success);
					navigationManager.NavigateTo("/Usuarios");
				}
				else
				{
					await Swal.FireAsync("Error", "No se pudo Eliminar el usuario", SweetAlertIcon.Error);
				}
			}
		}
	}
}
