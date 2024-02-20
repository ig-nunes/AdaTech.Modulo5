using DadosSistema.Models;
using DadosSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema
{
    public class DevolucaoRepositorioInMemory : IRepositorio<Devolucao>
    {
        private List<Devolucao> _devolucoes = new List<Devolucao>()
        {
            new Devolucao(1, 1, DateTime.Now),
        };

        public Devolucao Add(Devolucao devolucao)
        {
            _devolucoes.Add(devolucao);
            return devolucao;
        }

        public List<Devolucao> Get()
        {
            return _devolucoes;
        }

        public Devolucao? GetById(int id)
        {
            var devolucao = _devolucoes.FirstOrDefault(devolucao => devolucao.Id == id);

            return devolucao;
        }
    }
}
