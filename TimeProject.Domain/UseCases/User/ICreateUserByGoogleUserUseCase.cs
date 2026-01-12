using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    ICustomResult<IUser> Handle(ICreateUserOAtuhDto dto, string email);
}