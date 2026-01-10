using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    Task<Result<bool>> Handle(string email, string password);
}