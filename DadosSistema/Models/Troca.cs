using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Models
{
    public class Troca
    {
        private static int _id = 1;

        public int Id { get; }
        public int VendaId { get; }
        public int ItemVendaId { get; }
        public Produto ProdutoNovo { get; }

        public Troca(int vendaId, int itemVendaId, Produto produtoNovo)
        {
            Id = _id++;
            VendaId = vendaId;
            ItemVendaId = itemVendaId;
            ProdutoNovo = produtoNovo;
        }
    }
}
