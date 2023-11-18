using API.CartinhasParaNoel.Models.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace API.CartinhasParaNoel.Models.Request
{
    public class NovaCartaViewModel
    {
        public int idCarta { get; set; }

        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string nome { get; set; }

        [CartasValidationAttribute(ErrorMessage = "Idade deve ser maior que 15 anos")]
        public int idade { get; set; }

        [Required(ErrorMessage = "A descricao é obrigatória.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no maximo 500 caracteres")]
        public string descricao { get; set; }
        [Required(ErrorMessage = "A descricao é obrigatória.")]
        public string rua { get; set; }
        [Required(ErrorMessage = "A rua é obrigatória.")]
        public string cidade { get; set; }
        [Required(ErrorMessage = "A cidade é obrigatória.")]
        public string bairro { get; set; }
        [Required(ErrorMessage = "O bairro é obrigatória.")]
        public string estado { get; set; }
        [Required(ErrorMessage = "O numero é obrigatória.")]
        public int numero { get; set; }
    }
}
