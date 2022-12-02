using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
	public class Paciente
	{
		public string IdentidadPaciente { get; set; }
		public string Nombre { get; set; }
		public string Telefono { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Direccion { get; set; }
		public string EstadoCivil { get; set; }
		public string Genero { get; set; }
	}
}
