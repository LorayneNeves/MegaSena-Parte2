using API.CartinhasParaNoel.Models.CustomValidation;
using Microsoft.AspNetCore.Components.RenderTree;
using System.ComponentModel.DataAnnotations;

namespace API.CartinhasParaNoel.Models.Request
{
    public class CartaViewModel
    {

        public int idCarta { get; set; }
        public string nome { get; set; }
        public string rua { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string estado { get; set; }
        public int numero { get; set; }
        [CartasValidationAttribute]
        public int idade { get; set; }
        public string descricao { get; set; }      
    }
}
