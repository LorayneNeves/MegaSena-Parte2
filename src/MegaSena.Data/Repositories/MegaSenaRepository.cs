using MegaSena.Domain.Interfaces;
using MegaSena.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaSena.Application.ViewModels;

namespace MegaSena.Data.Repository
{
    public class MegaSenaRepository : IMegaSenaRepository
    {
        private readonly string _megaSenaCaminhoArquivo;

        #region - Construtores
        public MegaSenaRepository()
        {
            _megaSenaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "MegaSena.json");
        }
        #endregion
        public void Adicionar(JogoMegaSena megaSena)
        {
            var jogo = LerJogosArquivo();
            jogo.Add(megaSena);
            EscreverJogosNoArquivo(jogo);
        }

        IEnumerable<JogoMegaSena> IMegaSenaRepository.ObterTodos()
        {
            return LerJogosArquivo();
        }


        #region Métodos arquivo
        private List<JogoMegaSena> LerJogosArquivo()
        {
            if (!System.IO.File.Exists(_megaSenaCaminhoArquivo))
            {
                return new List<JogoMegaSena>();
            }

            string json = System.IO.File.ReadAllText(_megaSenaCaminhoArquivo);

            return JsonConvert.DeserializeObject<List<JogoMegaSena>>(json);
        }
        private void EscreverJogosNoArquivo(List<JogoMegaSena> megaSena)
        {
            string json = JsonConvert.SerializeObject(megaSena);
            System.IO.File.WriteAllText(_megaSenaCaminhoArquivo, json);
        }

        #endregion


    }
}