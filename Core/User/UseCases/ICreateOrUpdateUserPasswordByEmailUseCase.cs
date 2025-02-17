using Shared.General;

namespace Core.User.UseCases;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    Task<Result<bool>> Handle(string email, string password);
}