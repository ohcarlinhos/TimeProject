using Core.User.Repositories;
using Core.User.UseCases;
using Entities;
using Shared.General;
using TimeProject.Api.Infrastructure.Errors;

namespace TimeProject.Api.Modules.User.UseCases;

public class CreateOrUpdateUserPasswordByEmailUseCase(IUserPasswordRepository repo, IUserRepository userRepository)
    : ICreateOrUpdateUserPasswordByEmailUseCase
{
    public async Task<Result<bool>> Handle(string email, string password)
    {
        var result = new Result<bool>();
        var user = await userRepository.FindByEmail(email);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userPassword = await repo.FindByUserId(user.Id);

        if (userPassword != null)
        {
            userPassword.Password = BCrypt.Net.BCrypt.HashPassword(password);
            await repo.Update(userPassword);
        }
        else
        {
            await repo.Create(new UserPasswordEntity { Password = BCrypt.Net.BCrypt.HashPassword(password) });
        }

        result.Data = true;
        return result;
    }
}