using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackendAPI.Domain.Dtos
{
	public class PostPedidoDto
	{
		/// <summary>
		/// 
		/// </summary>
		/// <example>1234</example>
		public string CuentaCorriente { get; set; }

		/// <example>123412332</example>
		public string CodigoDeContratoInterno { get; set; }
	}
}
