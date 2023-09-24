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

        public MegaSenaRepository()
        {
            _megaSenaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "MegaSena.json");
        }

        public void Adicionar(JogoMegaSena megaSena)
        {
            List<JogoMegaSena> MegaSena = new List<JogoMegaSena>();
            int proximoCodigo = ObterProximoCodigoDisponivel();
            MegaSena.Add(megaSena);
            EscreverJogosNoArquivo(MegaSena);
        }
        public void Validation(JogoMegaSena megaSena)
        {
            throw new NotImplementedException();
        }

        public Task<JogoMegaSena> ObterPorId(Guid id) //int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JogoMegaSena>> ObterTodos(List<MegaSenaViewModel> listaJogos)
        {
            listaJogos = LerJogosArquivo();
            return ObterTodos(listaJogos);
        }


        #region Métodos arquivo
        private List<MegaSenaViewModel> LerJogosArquivo()
        {
            if (!System.IO.File.Exists(_megaSenaCaminhoArquivo))
            {
                return new List<MegaSenaViewModel>();
            }

            string json = System.IO.File.ReadAllText(_megaSenaCaminhoArquivo);
            if (string.IsNullOrEmpty(json))
            {
                return new List<MegaSenaViewModel>();
            }
            return JsonConvert.DeserializeObject<List<MegaSenaViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<MegaSenaView> megaSena = LerJogosArquivo();
            if (megaSena.Any())
            {
                return megaSena.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverJogosNoArquivo(List<JogoMegaSena> megaSena)
        {
            string json = JsonConvert.SerializeObject(megaSena);
            System.IO.File.WriteAllText(_megaSenaCaminhoArquivo, json);
        }

        public Task<IEnumerable<JogoMegaSena>> Validation()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<JogoMegaSena>> ObterTodos()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}