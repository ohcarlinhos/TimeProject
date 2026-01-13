using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Infrastructure.Database.Entities;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.Users;

public class CreateOrUpdateUserPasswordByEmailUseCase(IUserPasswordRepository repository, IUserRepository userRepository)
    : ICreateOrUpdateUserPasswordByEmailUseCase
{
    public ICustomResult<bool> Handle(string email, string password)
    {
        var result = new CustomResult<bool>();
        var user = userRepository.FindByEmail(email);

        if (user == null)
            return result.SetError(UserMessageErrors.NotFound);

        var userPassword = repository.FindByUserId(user.Id);

        if (userPassword != null)
        {
            userPassword.Password = BCrypt.Net.BCrypt.HashPassword(password);
            repository.Update(userPassword);
        }
        else
        {
            repository.Create(new UserPassword { Password = BCrypt.Net.BCrypt.HashPassword(password) });
        }

        result.Data = true;
        return result;
    }
}