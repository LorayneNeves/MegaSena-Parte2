using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.ViewModels
{
    public class MegaSenaViewModel
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Data { get; set; }
        public int[] NumeroDoJogo { get; set; }
    }
}
