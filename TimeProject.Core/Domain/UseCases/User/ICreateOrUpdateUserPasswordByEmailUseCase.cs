using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    Task<Result<bool>> Handle(string email, string password);
}