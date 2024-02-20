namespace DadosSistema.Models
{
    public class Venda
    {
        private static int _id = 1;

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Cliente { get; set; }
        public decimal ValorTotal { get => CalcularValorTotal(); }
        public List<ItemVenda> Itens { get; set; }

        public Venda(string cliente, List<ItemVenda> itens)
        {
            Id = _id++;
            Data = DateTime.Now;
            Cliente = cliente;
            Itens = itens;
            foreach (var item in itens)
            {
                item.VendaId = _id;
            }
        }

        private decimal CalcularValorTotal()
        {
            decimal total = 0;
            foreach (var item in Itens)
            {
                total += item.PrecoUnitario * item.Quantidade;
            }
            return total;
        }

    }
}
