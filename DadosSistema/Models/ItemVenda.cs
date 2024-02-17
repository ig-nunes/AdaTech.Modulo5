using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Models
{
    public class ItemVenda
    {
        private static int _id = 1;

        public int Id { get; set; }
        public Produto Produto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
        
        public ItemVenda(Produto produto, int quantidade)
        {
            Id = _id++;
            Produto = produto;
            PrecoUnitario = produto.Preco;
            Quantidade = quantidade;
        }

    }
}
