namespace TimeProject.Domain.RemoveDependencies.Dtos.Auth;

public interface ILoginGithubDto
{
    string AccessToken { get; set; }
    string TokenType { get; set; }
}