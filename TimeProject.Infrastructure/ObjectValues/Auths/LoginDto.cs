using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Auths;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Auths;

public class LoginDto : ILoginDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;

    [Required]
    [MinLength(8)]
    [MaxLength(48)]
    public string Password { get; set; } = string.Empty;
}