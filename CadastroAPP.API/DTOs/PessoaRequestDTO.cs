using System.ComponentModel.DataAnnotations;

namespace CadastroAPP.API.DTOs
{/// <summary>
/// modelo de dados para cadastro
/// </summary>
    public class PessoaRequestDTO
    {   // vc não recebe o ID esse será gerado no momento da inclusao no banco
        //public Guid Id { get; set; }
        [Required(ErrorMessage ="nome obrigatorio")]
        [MaxLength(50, ErrorMessage ="maxio de {1} carcteres")]
        [MinLength(3, ErrorMessage ="minimo de {1} caracteres")]
        public string? Nome { get; set; }
    }
}
