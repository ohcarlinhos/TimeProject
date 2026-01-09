using System.ComponentModel.DataAnnotations;

namespace TimeProject.Core.Application.Dtos.Auth;

public class LoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}