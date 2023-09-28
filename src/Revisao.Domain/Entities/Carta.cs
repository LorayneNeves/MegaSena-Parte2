using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Domain.Entities
{
    public class Carta
    {
        #region 1 - Contrutores
        public Carta(int codigo, string nome, string descricao, int idade, string rua, string bairro, int numero, string cidade, string estado)
        {
            idCarta = codigo;
            Nome = nome;
            Descricao = descricao;
            Idade = idade;
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }


        #endregion

        #region 2 - Propriedades
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
        #endregion

        #region 3 - Comportamentos
        public void AlterarDescricao(string descricao) => Descricao = descricao;

        public void SetaCodigoCarta(int novocodigo) => idCarta = novocodigo;

        #endregion
    }
}
