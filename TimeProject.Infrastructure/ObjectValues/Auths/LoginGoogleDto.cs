using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Auths;

namespace TimeProject.Infrastructure.ObjectValues.Auths;

public class LoginGoogleDto : ILoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}