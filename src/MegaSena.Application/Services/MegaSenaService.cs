using AutoMapper;
using MegaSena.Application.Interfaces;
using MegaSena.Application.ViewModels;
using MegaSena.Domain.Entities;
using MegaSena.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.Services
{
    public class MegaSenaService : IMegaSenaService
    {
        private readonly IMegaSenaRepository _megaSenaRepository;
        private IMapper _mapper;

        public MegaSenaService(IMegaSenaRepository megaSenaRepository, IMapper mapper)
        {
            _megaSenaRepository = megaSenaRepository;
            _mapper = mapper;
        }

        public void Adicionar(NovaMegaSenaViewModel novoJogoViewModel)
        {
            var novoJogo= _mapper.Map<JogoMegaSena>(novoJogoViewModel);
            _megaSenaRepository.Adicionar(novoJogo);

        }
       
        IEnumerable<MegaSenaViewModel> IMegaSenaService.ObterTodos()
        {
            return _mapper.Map<IEnumerable<MegaSenaViewModel>>(_megaSenaRepository.ObterTodos());
        }
    }
}
