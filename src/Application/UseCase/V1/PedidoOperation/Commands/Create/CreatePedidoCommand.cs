using Andreani.ARQ.Core.Interface;
using Andreani.ARQ.Pipeline.Clases;
using Andreani.ARQ.AMQStreams.Interface;
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
using Andreani.Scheme.Onboarding;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Create
{
	public class CreatePedidoCommand: IRequest<Response<CreatePedidoResponse>>
	{
		/// <example>123433</example>

		public PostPedidoDto PedidoACrear { get; set; }
		public CreatePedidoCommand(PostPedidoDto postPedidoDto) {
            PedidoACrear = postPedidoDto;
		}
    }

    public class CreatePedidoCommandHandler: IRequestHandler<CreatePedidoCommand, Response<CreatePedidoResponse>>
		{
			private readonly ITransactionalRepository _repository;
			private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher; 


			public CreatePedidoCommandHandler(ITransactionalRepository repository, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher)
			{
				_repository = repository;
				_publisher = publisher;
			}
			public async Task<Response<CreatePedidoResponse>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
			{
			var idPedido = Guid.NewGuid();
				var entity = new Pedidos()
				{
					CuentaCorriente = request.PedidoACrear.CuentaCorriente,
					CodigoDeContratoInterno = long.Parse(request.PedidoACrear.CodigoDeContratoInterno),
					Id = idPedido,
					NumeroDePedido = 0,
					EstadoDelPedido = 1,
					Cuando = DateTime.Now,
					CicloDelPedido = idPedido.ToString(),
				};
				_repository.Insert(entity);
				await _repository.SaveChangeAsync();

			await _publisher.To<Pedido>(new Andreani.Scheme.Onboarding.Pedido() {
				id = idPedido.ToString(),
				numeroDePedido = 12,
				cicloDelPedido = idPedido.ToString(),
                codigoDeContratoInterno = long.Parse(request.PedidoACrear.CodigoDeContratoInterno),
				estadoDelPedido = "1",
                cuentaCorriente = long.Parse(request.PedidoACrear.CuentaCorriente),
				cuando = DateTime.Now.ToString()
            }, idPedido.ToString());

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
