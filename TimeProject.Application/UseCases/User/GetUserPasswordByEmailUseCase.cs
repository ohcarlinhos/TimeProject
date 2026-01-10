using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Application.UseCases.User;

public class GetUserPasswordByEmailUseCase(IUserPasswordRepository repository, IUserRepository userRepository)
    : IGetUserPasswordByEmailUseCase
{
    public async Task<Result<GetUserPasswordByEmailResult>> Handle(string email)
    {
        var result = new Result<GetUserPasswordByEmailResult>();

        var user = await userRepository.FindByEmail(email);
        if (user == null) return result.SetError(UserMessageErrors.NotFound);

        var userPassword = await repository.FindByUserId(user.Id);
        return userPassword == null
            ? result.SetError(UserMessageErrors.PasswordNotAllowed)
            : result.SetData(new GetUserPasswordByEmailResult
                { UserPassword = userPassword, User = user });
    }
}