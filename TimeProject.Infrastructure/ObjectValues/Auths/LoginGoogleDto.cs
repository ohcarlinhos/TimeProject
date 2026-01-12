using System.ComponentModel.DataAnnotations;
using TimeProject.Domain.Dtos.Auths;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Auths;

public class LoginGoogleDto : ILoginGoogleDto
{
    [Required] public string AccessToken { get; set; } = string.Empty;
}