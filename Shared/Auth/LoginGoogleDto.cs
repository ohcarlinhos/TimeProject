using System.ComponentModel.DataAnnotations;

namespace Shared.Auth;

public class LoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}