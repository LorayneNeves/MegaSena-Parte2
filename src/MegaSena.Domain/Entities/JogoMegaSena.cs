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
        public JogoMegaSena(string nome, string cpf, DateTime data, int[] numerosjogo)
        {
            Nome = nome;
            Nome = nome;
            CPF = cpf;
            Data = data;
            NumeroDoJogo = numerosjogo;
        }


        public JogoMegaSena(int codigo, string nome, string cpf, DateTime data, int[] numerosjogo)
        {
            Codigo = codigo;
            Nome = nome;
            CPF = cpf;
            Data = data;
            NumeroDoJogo = numerosjogo;
        }
        #endregion

        #region 2 - Propriedades
        public int Codigo { get; private set; }
        [Required(ErrorMessage = "O nome e obrigatório.")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no maximo 255 caracteres")]
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public DateTime Data { get; private set; }

        //[NumerosValidation]
        public int[] NumeroDoJogo { get; private set; }

        #endregion

        #region 3 - Comportamentos

        public bool Validation(object? value)
        {
            if (value is int[] numeros)
            {
                // Verifica se tem exatamente 6 numeros
                if (numeros.Length != 6)
                {
                    return false;
                }

                // Verifica se os numeros estão entre 1 e 60
                if (numeros.Any(numero => numero < 1 || numero > 60))
                {
                    return false;
                }

                // Verifica se os numeros são todos diferentes
                if (numeros.Distinct().Count() != 6)
                {
                    return false;
                }

                return true;
            }

            // Se o valor não for um array de inteiros, a validação falha
            return false;
        }

        #endregion
    }
}
