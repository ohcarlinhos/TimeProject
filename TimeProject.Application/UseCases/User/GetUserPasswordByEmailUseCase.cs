using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class GetUserPasswordByEmailUseCase(IUserPasswordRepository repository, IUserRepository userRepository)
    : IGetUserPasswordByEmailUseCase
{
    public ICustomResult<IGetUserPasswordByEmailResult> Handle(string email)
    {
        var result = new CustomResult<IGetUserPasswordByEmailResult>();

        var user = userRepository.FindByEmail(email);
        if (user == null) return result.SetError(UserMessageErrors.NotFound);

        var userPassword = repository.FindByUserId(user.Id);
        return userPassword == null
            ? result.SetError(UserMessageErrors.PasswordNotAllowed)
            : result.SetData(new GetUserPasswordByEmailResult
                { UserPassword = userPassword, User = user });
    }
}