using System.ComponentModel.DataAnnotations;

namespace WebApi.RequestModels
{
    public class ProdutoRequest
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome do produto deve ter entre 1 e 30 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Preco é obrigatório.")]
        public decimal Preco { get; set; }
    }
}
