using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public class GetUserPasswordByEmailResult
{
    public UserPassword UserPassword { get; set; } = null!;
    public Entities.User User { get; set; } = null!;
}

public interface IGetUserPasswordByEmailUseCase
{
    Task<Result<GetUserPasswordByEmailResult>> Handle(string email);
}