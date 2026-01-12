using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Auths;

namespace TimeProject.Infrastructure.ObjectValues.Auths;

public class LoginGithubDto : ILoginGithubDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
    [Required] public string TokenType { get; set; } = string.Empty;
}