using System.ComponentModel.DataAnnotations;
using WebApi.Attributes;

namespace WebApi.RequestModels
{
    public class EntregadorRequest
    {
        [Required(ErrorMessage = "O CPF é obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O nsome é obrigatório")]
        [StringLength(30, ErrorMessage = "O nome não pode ter mais de 30 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        [MaiorDeIdade(ErrorMessage = "Você deve ser maior de 18 anos.")]
        public DateTime DataNascimento { get; set; }
    }
}
