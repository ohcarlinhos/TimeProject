using System.ComponentModel.DataAnnotations;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Auth;

public class LoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}