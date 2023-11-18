using AutoMapper;
using Revisao.Application.ViewModels;
using Revisao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.AutoMapper
{
	public class ApplicationToDomain : Profile
	{
		public ApplicationToDomain()
		{
			//Exemplo visto em sala de aula

			CreateMap<CartaViewModel, Carta>()
			.ConstructUsing(q => new Carta(q.idCarta, q.Nome, q.Descricao, q.Idade, q.Rua, q.Bairro, q.Numero, q.Cidade , q.Estado));

			CreateMap<NovaCartaViewModel, Carta>()
			.ConstructUsing(q => new Carta(q.idCarta, q.Nome, q.Descricao, q.Idade, q.Rua, q.Bairro, q.Numero, q.Cidade, q.Estado));

		}
	}
}
