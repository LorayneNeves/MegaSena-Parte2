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
    public class DomainToApplication : Profile
    {
        public DomainToApplication()
        {
            CreateMap<JogoMegaSena, MegaSenaViewModel>();
        }
    }
}
