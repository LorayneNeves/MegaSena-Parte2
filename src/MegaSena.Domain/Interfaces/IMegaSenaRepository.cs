using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaSena.Domain.Entities;

namespace MegaSena.Domain.Interfaces
{
    public interface IMegaSenaRepository
    {
        IEnumerable<JogoMegaSena> ObterTodos();
        void Adicionar(JogoMegaSena megaSena);

    }
}
