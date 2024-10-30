using Shared.General;

namespace Core.User.UseCases;

public interface ISetIsVerifiedUserUseCase
{
    Task<Result<bool>> Handle(int id, bool isVerified);
}