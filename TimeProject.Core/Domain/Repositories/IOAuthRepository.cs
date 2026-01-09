using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface IOAuthRepository
{
    public Task<OAuthEntity> Create(OAuthEntity entity);
    public Task<bool> Delete(int id);
    public Task<OAuthEntity?> FindByUserId(int userId);
    public Task<OAuthEntity?> FindByUserProviderId(string provider, string id);
}