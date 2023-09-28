using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.ViewModels
{
    public class CartaViewModel
    {
        public int idCarta { get; private set; }
        public string Nome { get; private set; }
        public string Rua { get; private set; }
        public string Cidade { get; private set; }
        public string Bairro { get; private set; }
        public string Estado { get; private set; }
        public int Numero { get; private set; }
        //[CartasValidationAttribute]
        public int Idade { get; private set; }
        public string Descricao { get; private set; }
    }
}
