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

        public MegaSenaService(IMegaSenaRepository produtoRepository, IMapper mapper)
        {
            _megaSenaRepository = produtoRepository;
            _mapper = mapper;
        }

        public void Adicionar(NovaMegaSenaViewModel novoProdutoViewModel)
        {
            var novoProduto = _mapper.Map<JogoMegaSena>(novoProdutoViewModel);
            _megaSenaRepository.Adicionar(novoProduto);

        }
        public Task<IEnumerable<MegaSenaViewModel>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<MegaSenaViewModel> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MegaSenaViewModel>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
