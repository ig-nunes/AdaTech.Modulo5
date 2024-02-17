using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Models
{
    public class Produto
    {
        private static int _id = 1;

        public int Id { get; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Id = _id++;
            Nome = nome;
            Preco = preco;
        }
    }
}
