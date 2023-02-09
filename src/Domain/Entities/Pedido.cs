using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Domain.Entities
{
    internal class Pedido
    {
        public int Id { get; set; }
        public int numeroDePedido { get; set; }
        public string cicloDelPedido { get; set; }
        public Int64 codigoDeContratoInterno { get; set; }
        public string cuentaCorriente { get; set; }
        public DateTime cuando { get; set; }
    }
}
