using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using DesafioBackendAPI.Application.UseCase.V1.PersonOperation.Commands.Create;
using DesafioBackendAPI.Domain.Dtos;
using DesafioBackendAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Create
{
	public class CreatePedidoCommand: IRequest<Response<CreatePedidoResponse>>
	{
		/// <example>123433</example>

		public PostPedidoDto Pedido { get; set; }
		public CreatePedidoCommand(PostPedidoDto postPedidoDto) {
			Pedido = postPedidoDto;
		}

		public class CreatePedidoCommandHandler: IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>>
		{
			private readonly ITransactionalRepository _repository;

			public CreatePedidoCommandHandler(ITransactionalRepository repository)
			{
				_repository = repository;
			}
			public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
			{
				var entity = new Pedidos()
				{
					CuentaCorriente = request.Pedido.CuentaCorriente,
					CodigoDeContratoInterno = long.Parse(request.Pedido.CodigoDeContratoInterno),
					Id = Guid.NewGuid(),
					NumeroDePedido = null,
					EstadoDelPedido = 1,
					Cuando = DateTime.Now,
					CicloDelPedido = Guid.NewGuid().ToString(),
				};
				_repository.Insert(entity);
				await _repository.SaveChangeAsync();

				return new Response<CreatePedidoResponse>
				{
					Content = new CreatePedidoResponse
					{
						Message = "Success",
						PedidoId = entity.Id.ToString(),
					},
					StatusCode = System.Net.HttpStatusCode.Created
				};

			}

		}
	}
}
