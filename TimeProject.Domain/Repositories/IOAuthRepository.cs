using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IOAuthRepository
{
    public IOAuth Create(IOAuth entity);
    public bool Delete(int id);
    public IOAuth? FindByUserId(int userId);
    public IOAuth? FindByUserProviderId(string provider, string id);
}