using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IUserProviderRepository
{
    public IUserProvider Create(IUserProvider entity);
    public bool Delete(int id);
    public IUserProvider? FindByUserId(int userId);
    public IUserProvider? FindByUserProviderId(string provider, string id);
}