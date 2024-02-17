namespace WebApi.RequestModels
{
    public class ItemVendaRequest
    {
        public int Quantidade { get; set; }
        public ProdutoRequest? ProdutoRequest { get; set; }
    }
}
