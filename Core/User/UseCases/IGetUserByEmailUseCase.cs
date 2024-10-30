using Entities;
using Shared.General;

namespace Core.User.UseCases;

public interface IGetUserByEmailUseCase
{
    Task<Result<UserEntity>> Handle(string email);
}