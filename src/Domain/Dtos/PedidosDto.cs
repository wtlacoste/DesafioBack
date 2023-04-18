using DesafioBackendAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Domain.Dtos
{

	public record struct PedidosDto(
	 Guid Id,
	 int? NumeroDePedido,
	 string? CicloDelPedido,
	 Int64? CodigoDeContratoInterno,
	 string? CuentaCorriente,
	 string? Cuando,
	 EstadoDelPedidoDto? EstadoDelPedido
	 ) { }

	
}
