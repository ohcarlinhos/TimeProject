namespace TimeProject.Domain.Dtos.Auths;

public interface ILoginGithubDto
{
    string AccessToken { get; set; }
    string TokenType { get; set; }
}