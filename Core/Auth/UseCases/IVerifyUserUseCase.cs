using Shared.General;

namespace Core.Auth.UseCases;

public interface IVerifyUserUseCase
{
    Task<Result<bool>> Handle(int id, string email, string code);
}