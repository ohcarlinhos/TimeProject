using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class CreateOrUpdateUserPasswordByEmailUseCase(IUserPasswordRepository repo, IUserRepository userRepository)
    : ICreateOrUpdateUserPasswordByEmailUseCase
{
    public async Task<ICustomResult<bool>> Handle(string email, string password)
    {
        var result = new CustomResult<bool>();
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
            await repo.Create(new UserPassword { Password = BCrypt.Net.BCrypt.HashPassword(password) });
        }

        result.Data = true;
        return result;
    }
}