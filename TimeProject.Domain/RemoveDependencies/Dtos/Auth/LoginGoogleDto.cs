using System.ComponentModel.DataAnnotations;

namespace TimeProject.Domain.RemoveDependencies.Dtos.Auth;

public interface ILoginGoogleDto
{
    string AccessToken { get; set; }
}

public class LoginGoogleDto : ILoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}