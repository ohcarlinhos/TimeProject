namespace TimeProject.Domain.Dtos.Auths;

public interface IJwtResult
{
    string Token { get; set; }
    string Refresh { get; set; }
    DateTime ValidFrom { get; set; }
    DateTime ValidTo { get; set; }
}