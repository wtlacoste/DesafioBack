using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using DesafioBackendAPI.Domain.Common;
using DesafioBackendAPI.Domain.Dtos;
using DesafioBackendAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList {

    public record struct GetPedido : IRequest<Response<PedidosDto>>
    {
        public string Id { get; set; }
    }
    public class PedidoHandler : IRequestHandler<GetPedido, Response<PedidosDto>> {

        private readonly IReadOnlyQuery _query;

        public PedidoHandler(IReadOnlyQuery query) {
            _query = query;
        }

        public async Task<Response<PedidosDto>> Handle(GetPedido request, CancellationToken cancellationToken) { 

            
            Guid IdABuscar = new Guid(request.Id);
        //el primer parametro parece ser el nombre del campo el segundo el valor a evaluar?
            var result = await _query.GetByIdAsync<Pedidos>(nameof(request.Id), request.Id);
			

			var response = new Response<PedidosDto>();

            if (result is null)
            {
                response.AddNotification("#3123", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_RECORD, "Pedido", request.Id));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;

                return response;

            }
			var sqlString = $"select * from dbo.estadoDelPedido where dbo.estadoDelPedido.id = '{result.EstadoDelPedido}'";

			var resultadoEstadoDelPedido = await _query.FirstOrDefaultQueryAsync<EstadoDelPedido>(sqlString);
			PedidosDto pedidoDto = new PedidosDto()
			{
				Id = (Guid)result.Id,
				CicloDelPedido = result.CicloDelPedido,
				NumeroDePedido = result.NumeroDePedido,
				Cuando = result.Cuando,
				CuentaCorriente = result.CuentaCorriente,
				CodigoDeContratoInterno = result.CodigoDeContratoInterno,
				EstadoDelPedido = new EstadoDelPedidoDto()
				{
					Id = resultadoEstadoDelPedido is null ? 1 : resultadoEstadoDelPedido.Id,
					Descripcion = resultadoEstadoDelPedido is null ? "VACIO" : resultadoEstadoDelPedido.Descripcion
				}
			};
			response.Content = pedidoDto;
            return response;

        }
	}
}
