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
    public class DetalleFacturaRepositorio : IDetalleFacturaRepositorio
    {
        private string CadenaConexion;

        public DetalleFacturaRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<bool> Nuevo(DetalleFactura detalleFactura)
        {
            bool inserto = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO detallefactura (IdFactura, CodigoServicio, Precio, Total) 
                               VALUES (@IdFactura, @CodigoServicio, @Precio, @Total);";
                inserto = Convert.ToBoolean(await conexion.ExecuteAsync(sql, detalleFactura));
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }
    }
}
