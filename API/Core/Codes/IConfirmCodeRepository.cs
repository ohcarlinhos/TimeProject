using Entities;

namespace API.Core.Codes;

public interface IConfirmCodeRepository
{
    Task<ConfirmCodeEntity> Create(ConfirmCodeEntity entity);
    Task<ConfirmCodeEntity> Update(ConfirmCodeEntity entity);
    Task<ConfirmCodeEntity?> FindById(string id);
    Task<ConfirmCodeEntity?> FindByIdAndEmail(string id, string email);
    Task<List<ConfirmCodeEntity>> FindByUserId(int userId);
    Task<List<ConfirmCodeEntity>> FindByUserId(int userId, ConfirmCodeType type);
}