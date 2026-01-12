using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IOAuthRepository
{
    public Task<IOAuth> Create(IOAuth entity);
    public Task<bool> Delete(int id);
    public Task<IOAuth?> FindByUserId(int userId);
    public Task<IOAuth?> FindByUserProviderId(string provider, string id);
}