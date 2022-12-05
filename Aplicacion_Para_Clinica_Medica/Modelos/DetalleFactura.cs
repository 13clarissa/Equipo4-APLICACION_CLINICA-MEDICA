using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int Factura_Id { get; set; }
        public int Servicio_Codigo { get; set; }
        public string Servicio { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
