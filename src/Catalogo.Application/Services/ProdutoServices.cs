using Catalogo.Application.Interfaces;
using Catalogo.Application.ViewModels;
using Catalogo.Domain.Entities;
using Catalogo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.Services
{
    public class ProdutoServices : IProdutoService
    {
        private readonly IProdutoRepository produtoRepository;
        public ProdutoServices(IProdutoRepository produtoRepository)
        {
            produtoRepository = produtoRepository;
        }

        public void Adicionar(NovoProdutoViewModel novoProdutoViewModel)
        {
            
            throw new NotImplementedException();
        }
        
    }
}
