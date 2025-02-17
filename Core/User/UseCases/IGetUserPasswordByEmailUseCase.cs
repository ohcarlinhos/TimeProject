using Entities;
using Shared.General;

namespace Core.User.UseCases;

public class GetUserPasswordByEmailResult
{
    public UserPasswordEntity UserPassword { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}

public interface IGetUserPasswordByEmailUseCase
{
    Task<Result<GetUserPasswordByEmailResult>> Handle(string email);
}