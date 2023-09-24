using MegaSena.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.Interfaces
{
    public interface IMegaSenaService
    {
        Task<IEnumerable<MegaSenaViewModel>> ObterTodos(NovaMegaSenaViewModel novaMegaSenaViewModel);
        Task<MegaSenaViewModel> ObterPorId(Guid id);
        Task<IEnumerable<MegaSenaViewModel>> ObterPorCategoria(int codigo);

        void Adicionar(NovaMegaSenaViewModel megaSena);


    }
}
