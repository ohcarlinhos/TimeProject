using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IVerifyUserUseCase
{
    Task<ICustomResult<bool>> Handle(int id, string email, string code);
}