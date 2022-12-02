using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
	public interface IPacienteRepositorio
	{
		Task<Paciente> GetPorCodigo(string identidadpaciente);
		Task<bool> Nuevo(Paciente paciente);
		Task<bool> Actualizar(Paciente paciente);
		Task<bool> Eliminar(string identidadpaciente);
		Task<IEnumerable<Paciente>> GetLista();
	}
}
