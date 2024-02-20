using System.ComponentModel.DataAnnotations;

namespace WebApi.RequestModels
{
    public class ItemVendaRequest
    {
        [Required(ErrorMessage = "O campo Quantidade é obrigatório.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O campo ProdutoRequest é obrigatório.")]
        public ProdutoRequest ProdutoRequest { get; set; }
    }
}
