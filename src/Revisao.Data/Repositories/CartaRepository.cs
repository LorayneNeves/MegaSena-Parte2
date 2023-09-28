using Newtonsoft.Json;
using Revisao.Domain.Entities;
using Revisao.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Data.Repositories
{
    public class CartaRepository : ICartaRepository
    {
        private readonly string _cartaCaminhoArquivo;

        #region - Construtores
        public CartaRepository()
        {
            _cartaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "produto.json");
        }

        #endregion

        #region - Funções
        public void Adicionar(Carta carta)
        {
            var cartas = LerCartasDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();
            carta.SetaCodigoCarta(proximoCodigo);
            cartas.Add(carta);
            EscreverCartasNoArquivo(cartas);
        }

        public void Atualizar(Carta produto)
        {
            throw new NotImplementedException();
        }
        Task<IEnumerable<Carta>> ICartaRepository.ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        Task<Carta> ICartaRepository.ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Carta> ICartaRepository.ObterTodos()
        {
            return LerCartasDoArquivo();
        }
        #endregion
        #region - Métodos arquivo
        private List<Carta> LerCartasDoArquivo()
        {
            if (!System.IO.File.Exists(_cartaCaminhoArquivo))
                return new List<Carta>();
            string json = System.IO.File.ReadAllText(_cartaCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Carta>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Carta> produtos = LerCartasDoArquivo();
            if (produtos.Any())
                return produtos.Max(p => p.idCarta) + 1;
            else
                return 1;
        }

        private void EscreverCartasNoArquivo(List<Carta> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_cartaCaminhoArquivo, json);
        }
        #endregion

    }
}
