using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.Repositories;

public interface IConfirmCodeRepository
{
    Task<ConfirmCodeEntity> Create(ConfirmCodeEntity entity);
    Task<ConfirmCodeEntity> Update(ConfirmCodeEntity entity);
    Task<ConfirmCodeEntity?> FindById(string id);
    Task<ConfirmCodeEntity?> FindByIdAndEmail(string id, string email);
    Task<List<ConfirmCodeEntity>> FindByUserId(int userId);
    Task<List<ConfirmCodeEntity>> FindByUserId(int userId, ConfirmCodeType type);
    Task<List<ConfirmCodeEntity>> FindByUserIdThatIsNotExpiredOrUsed(int userId, ConfirmCodeType type);
}