using MegaSena.Application.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSena.Application.ViewModels
{
    public class MegaSenaViewModel
    {
        public string Nome { get; set; }
        [CpfValidation]
        public string CPF { get; set; }
        public DateTime Data { get; set; }

        [JogoValidationAttribute]
        public int[] NumeroDoJogo { get; set; }
    }
}
