using Clinica_Medica.Interfaces;
using Clinica_Medica.Pages.MisPacientes;
using Clinica_Medica.Pages.MisUsuarios;
using Datos.Interfaces;
using Datos.Repositorios;
using Modelos;

namespace Clinica_Medica.Service
{
	public class PacienteService : IPacienteService
	{

		private readonly Config _configuracion;
		private IPacienteRepositorio pacienteRepositorio;

		public PacienteService(Config config)
		{
			_configuracion = config;
			pacienteRepositorio = new PacienteRepositorio(config.CadenaConexion);
		}
		public async Task<bool> Actualizar(Paciente paciente)
		{
			return await pacienteRepositorio.Actualizar(paciente);
		}

		public async Task<bool> Eliminar(string identidadpaciente)
		{
			return await pacienteRepositorio.Eliminar(identidadpaciente);
		}

		public async Task<IEnumerable<Paciente>> GetLista()
		{
			return await pacienteRepositorio.GetLista();
		}

		public async Task<Paciente> GetPorCodigo(string identidadpaciente)
		{
			return await pacienteRepositorio.GetPorCodigo(identidadpaciente);
		}

		public async Task<bool> Nuevo(Paciente paciente)
		{
			return await pacienteRepositorio.Nuevo(paciente);
		}
	}
}
