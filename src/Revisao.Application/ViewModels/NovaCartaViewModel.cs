using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Application.ViewModels
{
    public class NovaCartaViewModel
    {
        public int idCarta { get; set; }

        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Idade e obrigatório.")]

        [Range(0,14, ErrorMessage = "Idade deve ser menor que 15 anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "A descricao é obrigatória.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no maximo 500 caracteres")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "A descricao é obrigatória.")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O bairro é obrigatória.")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "O numero é obrigatória.")]
        public int Numero { get; set; }
    }
}
