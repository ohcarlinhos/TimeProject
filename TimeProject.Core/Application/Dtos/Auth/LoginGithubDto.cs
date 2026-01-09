using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.Auth;

public class LoginGithubDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
    [Required] public string TokenType { get; set; } = string.Empty;
}