using Andreani.ARQ.Core.Interface;
using Andreani.Scheme.Onboarding;
using DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Create;
using DesafioBackendAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Update
{
	public class GuardarPedidoAsignadoCommand : IRequest<GuardarPedidoResponse>
	{
		public Pedido pedido { get; set; }


	}

	public class GuardarPedidoAsignadoCommandHandler: IRequestHandler<GuardarPedidoAsignadoCommand, GuardarPedidoResponse>
	{
		private readonly IReadOnlyQuery _query;
		private readonly ITransactionalRepository _repository;
		private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;


		public GuardarPedidoAsignadoCommandHandler(ITransactionalRepository repository, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher)
		{
			_repository = repository;
			_publisher = publisher;
	}

	public async Task<GuardarPedidoResponse> Handle(GuardarPedidoAsignadoCommand request, CancellationToken cancellationToken)
		{
			Pedido pedidoToUpdate = request.pedido;
			var idPedido = pedidoToUpdate.id;
			var entity = new Pedidos()
			{
				CuentaCorriente = pedidoToUpdate.cuentaCorriente.ToString(),
				CodigoDeContratoInterno = pedidoToUpdate.codigoDeContratoInterno,
				Id = Guid.Parse(idPedido),
				NumeroDePedido = pedidoToUpdate.numeroDePedido,
				EstadoDelPedido = 2,
				Cuando = DateTime.ParseExact(pedidoToUpdate.cuando, "MM/dd/yyyy hh:mm:ss", null),

				CicloDelPedido = pedidoToUpdate.cicloDelPedido,
			};
			_repository.Update(entity);
			await _repository.SaveChangeAsync();

			return new GuardarPedidoResponse();
		}
	}
	public class GuardarPedidoResponse
	{
	}
}
