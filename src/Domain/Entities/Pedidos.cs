using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Domain.Entities
{
    public class Pedidos
    {
        public Guid? Id { get; set; }
        public int? NumeroDePedido { get; set; }
        public string? CicloDelPedido { get; set; }
        public Int64? CodigoDeContratoInterno { get; set; }
        public string? CuentaCorriente { get; set; }
        public DateTime? Cuando { get; set; }
        public int? EstadoDelPedido { get; set; }
    }
}
