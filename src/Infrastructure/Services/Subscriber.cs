using Andreani.ARQ.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Update;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Infrastructure.Services
{
	public class Subscriber: ISubscriber
	{
		private Andreani.ARQ.AMQStreams.Interface.IPublisher _publisher;
		private ILogger<Subscriber> _logger;
		private ISender _mediator;

		public Subscriber(ILogger<Subscriber> logger, Andreani.ARQ.AMQStreams.Interface.IPublisher publisher, ISender mediator)
		{
			_logger = logger;
			_publisher = publisher;
			_mediator = mediator;
		}
		public async Task ReceivePedidoCreado(Pedido pedido)
		{
			await _mediator.Send(new GuardarPedidoAsignadoCommand() { pedido = pedido });

		}
	}
}
