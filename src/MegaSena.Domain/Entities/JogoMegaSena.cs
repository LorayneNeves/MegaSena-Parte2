using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Domain.Entities
{
    public class JogoMegaSena
    { 
        #region 1 - Contrutores
        public JogoMegaSena(string nome, string cPF, DateTime data, int[] numeroDoJogo)
        {
            Nome = nome;
            CPF = cPF;
            Data = data;
            NumeroDoJogo = numeroDoJogo;
        }
        #endregion

        #region 2 - Propriedades
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime Data { get; private set; }
        public int[] NumeroDoJogo { get; private set; }

        #endregion
    }
}
