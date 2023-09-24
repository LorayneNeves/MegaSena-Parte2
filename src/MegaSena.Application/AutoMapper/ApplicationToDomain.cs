using AutoMapper;
using MegaSena.Application.ViewModels;
using MegaSena.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.AutoMapper
{
    public class ApplicationToDomain : Profile
    {
        public ApplicationToDomain()
        {

            CreateMap<MegaSenaViewModel, JogoMegaSena>()
               .ConstructUsing(q => new JogoMegaSena(q.Codigo, q.Nome, q.CPF, q.Data, q.NumeroDoJogo));

            CreateMap<NovaMegaSenaViewModel, JogoMegaSena>()
               .ConstructUsing(q => new JogoMegaSena(q.Nome, q.CPF, q.Data, q.NumeroDoJogo));

        }
    }
}
