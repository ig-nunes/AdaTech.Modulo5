using DadosSistema.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApi.RequestModels
{
    public class TrocaRequest
    {
        [Required(ErrorMessage = "O campo VendaId é obrigatório.")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O campo ItemVendaId é obrigatório.")]
        public int ItemVendaId { get; set; }

        [Required(ErrorMessage = "O campo ProdutoNovo é obrigatório.")]
        public Produto ProdutoNovo { get; set; }
    }
}
