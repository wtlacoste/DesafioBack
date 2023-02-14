using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using DesafioBackendAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.EstadoPedido.Queries
{
	public class ListEstados : IRequest<Response<List<EstadoDelPedido>>>
	{

	}
	public class ListEstadosHandler : IRequestHandler<ListEstados, Response<List<EstadoDelPedido>>>
	{
		private readonly IReadOnlyQuery _query;
	public ListEstadosHandler(IReadOnlyQuery query)
	{
		_query = query;
	}

		public async Task<Response<List<EstadoDelPedido>>> Handle(ListEstados request, CancellationToken cancellationToken)
		{
			var result = await _query.GetAllAsync<EstadoDelPedido>();
			return new Response<List<EstadoDelPedido>>
			{
				Content = result.ToList(),
				StatusCode = System.Net.HttpStatusCode.OK
			};
		}
	}
	
	
}
