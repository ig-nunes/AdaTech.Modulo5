using DadosSistema.Models;
using DadosSistema.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema
{
    public class TrocaRepositorioInMemory : IRepositorio<Troca>
    {
        private List<Troca> _trocas = new List<Troca>() 
        {
            new Troca(1, 1, new Produto("ProdutoNovo1", 10.0m)),
            new Troca(2, 2, new Produto("ProdutoNovo2", 20.0m)),
        };

        public Troca Add(Troca troca)
        {
            _trocas.Add(troca);
            return troca;
        }

        public List<Troca> Get()
        {
            return _trocas;
        }

        public Troca? GetById(int id)
        {
            return _trocas.FirstOrDefault(t => t.Id == id);
        }

        public List<Troca> GetTrocasPorVenda(int vendaId)
        {
            return _trocas.Where(t => t.VendaId == vendaId).ToList();
        }
    }
}
