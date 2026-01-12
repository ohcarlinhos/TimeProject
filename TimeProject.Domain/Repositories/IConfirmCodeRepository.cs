using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Infrastructure.Database.Entities.Enums;

namespace TimeProject.Domain.Repositories;

public interface IConfirmCodeRepository
{
    IConfirmCode Create(IConfirmCode entity);
    IConfirmCode Update(IConfirmCode entity);
    IConfirmCode? FindById(string id);
    IConfirmCode? FindByIdAndEmail(string id, string email);
    IList<IConfirmCode> FindByUserId(int userId);
    IList<IConfirmCode> FindByUserId(int userId, ConfirmCodeType type);
    IList<IConfirmCode> FindByUserIdThatIsNotExpiredOrUsed(int userId, ConfirmCodeType type);
}