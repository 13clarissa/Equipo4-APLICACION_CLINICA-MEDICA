using Modelos;

namespace Clinica_Medica.Interfaces
{
	public interface IPacienteService
	{
		Task<Paciente> GetPorCodigo(string identidadpaciente);
		Task<bool> Nuevo(Paciente paciente);
		Task<bool> Actualizar(Paciente paciente);
		Task<bool> Eliminar(string identidadpaciente);
		Task<IEnumerable<Paciente>> GetLista();
	}
}
