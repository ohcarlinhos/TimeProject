using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface IGetUserByEmailUseCase
{
    ICustomResult<IUser> Handle(string email);
}