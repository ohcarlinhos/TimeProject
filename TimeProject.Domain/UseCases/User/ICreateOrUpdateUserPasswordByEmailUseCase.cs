using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordByEmailUseCase
{
    Task<ICustomResult<bool>> Handle(string email, string password);
}