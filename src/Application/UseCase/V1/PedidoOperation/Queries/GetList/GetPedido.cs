using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using DesafioBackendAPI.Domain.Common;
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

    public record struct GetPedido : IRequest<Response<Pedidos>>
    {
        public string Id { get; set; }
    }
    public class PedidoHandler : IRequestHandler<GetPedido, Response<Pedidos>> {

        private readonly IReadOnlyQuery _query;

        public PedidoHandler(IReadOnlyQuery query) {
            _query = query;
        }

        public async Task<Response<Pedidos>> Handle(GetPedido request, CancellationToken cancellationToken) { 

            
            Guid IdABuscar = new Guid(request.Id);
        //el primer parametro parece ser el nombre del campo el segundo el valor a evaluar?
            var result = await _query.GetByIdAsync<Pedidos>(nameof(request.Id), request.Id);
            
            var response = new Response<Pedidos>();

            if (result is null)
            {
                response.AddNotification("#3123", nameof(request.Id), string.Format(ErrorMessage.NOT_FOUND_RECORD, "Pedido", request.Id));
                response.StatusCode = System.Net.HttpStatusCode.NotFound;

                return response;

            }
            response.Content = result;
            return response;

        }
	}
}
