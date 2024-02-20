using System.ComponentModel.DataAnnotations;

namespace WebApi.RequestModels
{
    public class DevolucaoRequest
    {
        [Required(ErrorMessage = "O campo VendaId é obrigatório.")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O campo ItemId é obrigatório.")]
        public int ItemId { get; set; }
    }
}
