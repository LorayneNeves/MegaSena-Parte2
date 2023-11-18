using Catalogo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOJAH1.Catalogo.Application.Interfaces
{
    public interface IProdutoService
    {
        void Adicionar(NovoProdutoViewModel novoProdutoViewModel);

    }
}