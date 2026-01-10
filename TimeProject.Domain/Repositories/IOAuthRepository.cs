using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IOAuthRepository
{
    public Task<OAuth> Create(OAuth entity);
    public Task<bool> Delete(int id);
    public Task<OAuth?> FindByUserId(int userId);
    public Task<OAuth?> FindByUserProviderId(string provider, string id);
}