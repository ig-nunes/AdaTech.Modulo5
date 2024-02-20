using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DadosSistema.Models
{
    public class Devolucao
    {
        public static int _id = 1;
        public Devolucao(int vendaId, int itemVendaId, DateTime createdAt)
        {
            Id = _id++;
            VendaId = vendaId;
            ItemVendaId = itemVendaId;
            CreatedAt = createdAt;
        }

        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ItemVendaId { get; set; }
        //public Produto Produto { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
