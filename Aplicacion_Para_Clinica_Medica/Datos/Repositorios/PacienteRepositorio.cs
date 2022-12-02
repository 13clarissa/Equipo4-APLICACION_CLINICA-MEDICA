using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
	public class PacienteRepositorio : IPacienteRepositorio
	{
		private string CadenaConexion;

		public PacienteRepositorio(string _cadenaConexion)
		{
			CadenaConexion = _cadenaConexion;
		}

		private MySqlConnection Conexion()
		{
			return new MySqlConnection(CadenaConexion);
		}
		public async Task<bool> Actualizar(Paciente paciente)
		{
			bool resultado = false;
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = @"UPDATE paciente SET Nombre = @Nombre, Telefono = @Telefono, FechaNacimiento=  @FechaNacimiento, Direccion = @Direccion
                       EstadoCivil = @EstadoCivil, Genero = @Genero WHERE IdentidadPaciente = @IdentidadPaciente;";
				resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, paciente));
			}
			catch (Exception ex)
			{
			}
			return resultado;
		}

		public async Task<bool> Eliminar(string identidadpaciente)
		{
			bool resultado = false;
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = @"DELETE FROM paciente WHERE IdentidadPaciente = @IdentidadPaciente;";
				resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { identidadpaciente }));
			}
			catch (Exception ex)
			{
			}
			return resultado;
		}
		public async Task<IEnumerable<Paciente>> GetLista()
		{
			IEnumerable<Paciente> lista = new List<Paciente>();
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = "SELECT * FROM paciente;";
				lista = await conexion.QueryAsync<Paciente>(sql);
			}
			catch (Exception ex)
			{
			}
			return lista;
		}

		public async  Task<Paciente> GetPorCodigo(string identidadpaciente)
		{
			Paciente pacien = new Paciente();
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = "SELECT * FROM paciente WHERE identidadPaciente = @identidadPaciente;";
				pacien = await conexion.QueryFirstAsync<Paciente>(sql, new { identidadpaciente });
			}
			catch (Exception ex)
			{
			}
			return pacien;
		}

		public async Task<bool> Nuevo(Paciente paciente)
		{
			bool resultado = false;
			try
			{
				using MySqlConnection conexion = Conexion();
				await conexion.OpenAsync();
				string sql = @"INSERT INTO paciente (IdentidadPaciente, Nombre, Telefono, FechaNacimiento, Direccion, EstadoCivil, Genero) VALUES (@IdentidadPaciente, @Nombre, @Telefono, 
                         @FechaNacimiento, @Direccion, @EstadoCivil, @Genero);";
				resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, paciente));
			}
			catch (Exception ex)
			{
			}
			return resultado;
		}
	
	}
}
