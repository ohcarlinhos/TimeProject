using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PomodoroAPI.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(120)]
        public string Nome { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, MinLength(8), MaxLength(32)]
        public string Senha { get; set; }
    }
}
