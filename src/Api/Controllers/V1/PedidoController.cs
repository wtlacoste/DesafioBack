using DesafioBackendAPI.Application.UseCase.V1.PersonOperation.Queries.GetList;
using MediatR;
using Andreani.ARQ.WebHost.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList;

namespace WebApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PedidoController : ApiControllerBase
    {

	[HttpGet]
	public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPedido()));

	[HttpGet("{id}")]
    public async Task<IActionResult> Get(string id) => this.Result(await Mediator.Send(new PedidoCommand() { Id = new Guid(id)} ));




}