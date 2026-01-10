using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserByEmailUseCase
{
    Task<Result<UserEntity>> Handle(string email);
}