using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class CreateOrUpdateUserPasswordByEmailUseCase(IUserPasswordRepository repo, IUserRepository userRepository)
    : ICreateOrUpdateUserPasswordByEmailUseCase
{
    public ICustomResult<bool> Handle(string email, string password)
    {
        var result = new CustomResult<bool>();
        var user = userRepository.FindByEmail(email);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userPassword = repo.FindByUserId(user.Id);

        if (userPassword != null)
        {
            userPassword.Password = BCrypt.Net.BCrypt.HashPassword(password);
            repo.Update(userPassword);
        }
        else
        {
            repo.Create(new UserPassword { Password = BCrypt.Net.BCrypt.HashPassword(password) });
        }

        result.Data = true;
        return result;
    }
}