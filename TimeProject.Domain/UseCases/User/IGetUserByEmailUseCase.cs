using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByEmailUseCase
{
    Task<ICustomResult<IUser>> Handle(string email);
}