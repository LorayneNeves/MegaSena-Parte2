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
        IEnumerable<MegaSenaViewModel> ObterTodos();
        void Adicionar(NovaMegaSenaViewModel megaSena);
    }
}
