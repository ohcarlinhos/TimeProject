using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.RemoveDependencies.Dtos.Auth;

namespace TimeProject.Infrastructure.ObjectValues.Auths;

public class LoginGoogleDto : ILoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}