using Entities;
using Shared.General;

namespace API.Core.Codes;

public interface IConfirmCodeServices
{
    Task<Result<ConfirmCodeEntity>> CreateRecovery(int userId);
    Task<Result<bool>> Validate(string id, string email);
    Task<Result<bool>> SetUsed(string id);
}