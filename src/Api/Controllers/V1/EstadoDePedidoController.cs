using Andreani.ARQ.WebHost.Controllers;
using DesafioBackendAPI.Application.UseCase.V1.EstadoPedido.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Controllers.V1
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class EstadoDePedidoController : ApiControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListEstados()));
	}
}
