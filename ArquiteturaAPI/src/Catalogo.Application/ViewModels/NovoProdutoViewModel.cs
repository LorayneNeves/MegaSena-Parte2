using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo.Application.ViewModels
{
    public class NovoProdutoViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int QtdeEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
