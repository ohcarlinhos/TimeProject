using Core.User.Repositories;
using Core.User.UseCases;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

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