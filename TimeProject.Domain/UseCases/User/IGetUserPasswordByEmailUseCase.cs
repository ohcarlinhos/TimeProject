using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public class GetUserPasswordByEmailResult
{
    public UserPasswordEntity UserPassword { get; set; } = null!;
    public UserEntity User { get; set; } = null!;
}

public interface IGetUserPasswordByEmailUseCase
{
    Task<Result<GetUserPasswordByEmailResult>> Handle(string email);
}