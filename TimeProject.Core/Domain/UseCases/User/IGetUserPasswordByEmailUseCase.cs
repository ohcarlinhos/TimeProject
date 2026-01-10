using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public class GetUserPasswordByEmailResult
{
    public UserPasswordEntity UserPassword { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}

public interface IGetUserPasswordByEmailUseCase
{
    Task<Result<GetUserPasswordByEmailResult>> Handle(string email);
}