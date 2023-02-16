using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Application.UseCase.V1.PedidoOperation.Queries.GetList
{
	public class GetPedidoValidation : AbstractValidator<GetPedido>
	{
		public GetPedidoValidation() {
			RuleFor(x => x.Id)
				.NotEmpty()
				.WithMessage("Id no puede estar vacio")
				.Length(36)
				.WithMessage("Largo de Id invalido")
				.Matches("[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}")
				.WithMessage("Expresion sin formato de GuId")
				;
			;
		}
	}
	
}
