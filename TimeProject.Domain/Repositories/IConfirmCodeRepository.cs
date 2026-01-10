using TimeProject.Domain.Entities;

namespace TimeProject.Domain.Repositories;

public interface IConfirmCodeRepository
{
    Task<ConfirmCode> Create(ConfirmCode entity);
    Task<ConfirmCode> Update(ConfirmCode entity);
    Task<ConfirmCode?> FindById(string id);
    Task<ConfirmCode?> FindByIdAndEmail(string id, string email);
    Task<IList<ConfirmCode>> FindByUserId(int userId);
    Task<IList<ConfirmCode>> FindByUserId(int userId, ConfirmCodeType type);
    Task<IList<ConfirmCode>> FindByUserIdThatIsNotExpiredOrUsed(int userId, ConfirmCodeType type);
}