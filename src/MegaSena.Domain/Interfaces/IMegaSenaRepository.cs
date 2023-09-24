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
        Task<IEnumerable<JogoMegaSena>> ObterTodos();
        Task<JogoMegaSena> ObterPorId(Guid id);
        Task<IEnumerable<JogoMegaSena>> Validation();

        // void Validation(MegaSena megaSena);
        void Adicionar(JogoMegaSena megaSena);
        void Validation(JogoMegaSena megaSena);

    }
}
