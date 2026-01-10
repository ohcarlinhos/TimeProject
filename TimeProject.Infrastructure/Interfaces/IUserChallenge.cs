namespace TimeProject.Infrastructure.Interfaces;

public interface IUserChallenge
{
    public Task<bool> Test(string token);
}