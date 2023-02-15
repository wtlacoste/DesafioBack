using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
	public class GetPedidoValidation : AbstractValidator<PedidoCommand>
	{
		public GetPedidoValidation() {
			RuleFor(x => x.Id).NotEmpty().WithMessage("Id no puede estar vacio");
			;
		}
	}
	
}
