using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserByEmailUseCase
{
    Task<Result<UserEntity>> Handle(string email);
}