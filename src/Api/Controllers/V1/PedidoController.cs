using MediatR;
using Andreani.ARQ.WebHost.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList;
using DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Commands.Create;

using DesafioBackendAPI.Domain.Dtos;
using Andreani.ARQ.Pipeline.Clases;
using Microsoft.AspNetCore.Http;
using DesafioBackendAPI.Domain.Entities;

namespace WebApi.Controllers.V1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class PedidoController : ApiControllerBase
{

	[HttpGet]
	public async Task<IActionResult> Get() => Result(await Mediator.Send(new ListPedido()));

	[HttpGet("{id}")]
	[ProducesResponseType(typeof(Response<Pedidos>), StatusCodes.Status200OK)]
	[ProducesResponseType(typeof(List<Notify>), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Get(string id) => this.Result(await Mediator.Send(new GetPedido() { Id = id }));

	public async Task<IActionResult> Get(string id) => this.Result(await Mediator.Send(new GetPedido() { Id = id }));


	[HttpPost]
	public async Task<IActionResult> Create(PostPedidoDto body)  {

		return Result(await Mediator.Send(new CreatePedidoCommand(body)));
	}




}