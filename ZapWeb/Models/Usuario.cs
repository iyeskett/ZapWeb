using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZapWeb.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(100, ErrorMessage = "{0} deve ser menor que {1} caracteres")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "{0} é obrigatório.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "{0} deve estar entre {2} e {1} caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;

        public bool IsOnline { get; set; }

        [NotMapped]
        public string ConnectionId { get; set; } = null!;
    }
}