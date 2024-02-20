using DadosSistema.Models;

namespace WebApi.RequestModels
{
    public class TrocaRequest
    {
        public int VendaId { get; set; }
        public int ItemVendaId { get; set; }
        public Produto ProdutoNovo { get; set; }
    }
}
