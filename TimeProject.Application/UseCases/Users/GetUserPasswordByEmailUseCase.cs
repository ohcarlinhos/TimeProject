using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Pagination;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Pagination.Users;

namespace TimeProject.Application.UseCases.Users;

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