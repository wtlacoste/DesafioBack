using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using DesafioBackendAPI.Domain.Dtos;
using DesafioBackendAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList {

    public record struct ListPedido : IRequest<Response<List<PedidosDto>>>
    {

    }
    public class ListPedidoHandler : IRequestHandler<ListPedido, Response<List<PedidosDto>>> {

        private readonly IReadOnlyQuery _query;

        public ListPedidoHandler(IReadOnlyQuery query) {
            _query= query;
        }

		public async Task<Response<List<PedidosDto>>> Handle(ListPedido request, CancellationToken cancellationToken)
		{
              var result = await _query.GetAllAsync<Pedidos>(nameof(Pedidos));
            //var result = await _query.ExecuteQueryAsync<Pedidos>($"select TOP(100) * from dbo.pedidos", nameof(Pedidos));

			List <PedidosDto> resultPedidos = new List<PedidosDto>();
            foreach (var item in result) {
                var sqlString = $"select * from dbo.estadoDelPedido where dbo.estadoDelPedido.id = '{item.EstadoDelPedido}'";
                var resultadoEstadoDelPedido = await _query.FirstOrDefaultQueryAsync<EstadoDelPedido>(sqlString);
                
                PedidosDto pedidoDto = new PedidosDto() { 
                Id= (Guid)item.Id,
                CicloDelPedido=item.CicloDelPedido,
                NumeroDePedido=item.NumeroDePedido,
                Cuando=item.Cuando.ToString(),
                CuentaCorriente=item.CuentaCorriente,
                CodigoDeContratoInterno=item.CodigoDeContratoInterno,
                EstadoDelPedido= new EstadoDelPedidoDto() {
                    Id = resultadoEstadoDelPedido is null ?  1 : resultadoEstadoDelPedido.Id ,
					Descripcion = resultadoEstadoDelPedido is null ? "VACIO" :  resultadoEstadoDelPedido.Descripcion}
				};
                resultPedidos.Add(pedidoDto);
 
            }
            return new Response<List<PedidosDto>>
            {
                Content = resultPedidos,
                StatusCode = System.Net.HttpStatusCode.OK
            };
		}
	}
}
