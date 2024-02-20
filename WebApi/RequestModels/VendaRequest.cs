using DadosSistema.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApi.RequestModels
{
    public class VendaRequest
    {
        [Required(ErrorMessage = "O campo Cliente é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome do cliente deve ter entre 1 e 50 caracteres.")]
        public string? Cliente { get; set; }

        [Required(ErrorMessage = "A lista de itens da venda é obrigatória.")]
        [MinLength(1, ErrorMessage = "A lista de itens da venda deve conter pelo menos um item.")]
        public List<ItemVendaRequest>? ItemVendaRequests { get; set; }
    }
}
