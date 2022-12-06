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
    public class ServicioRepositorio : IServicioRepositorio
    {
        private string CadenaConexion;

        public ServicioRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> Actualizar(Servicio servicio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"UPDATE servicio SET Descripcion = @Descripcion, Precio = @Precio, FechaCreacion = @FechaCreacion, 
                               Imagen = @Imagen CitasDisponibles = @CitasDisponibles WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, servicio));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(int codigo)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"DELETE FROM servicio WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, new { codigo }));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Servicio>> GetLista()
        {
            IEnumerable<Servicio> lista = new List<Servicio>();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM servicio;";
                lista = await conexion.QueryAsync<Servicio>(sql);
            }
            catch (Exception ex)
            {
            }
            return lista;
        }

        public async Task<Servicio> GetPorCodigo(int codigo)
        {
            Servicio servicios = new Servicio();
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT * FROM servicio WHERE Codigo = @Codigo;";
                servicios = await conexion.QueryFirstOrDefaultAsync<Servicio>(sql, new { codigo });
            }
            catch (Exception ex)
            {
            }
            return servicios;
        }

        public async Task<bool> Nuevo(Servicio servicio)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO servicio (Codigo, Descripcion, Precio, FechaCreacion, Imagen) 
                               VALUES (@Codigo, @Descripcion, @Precio, @FechaCreacion, @Imagen);";
                resultado = Convert.ToBoolean(await conexion.ExecuteAsync(sql, servicio));
            }
            catch (Exception ex)
            {
            }
            return resultado;
        }
    }
}
