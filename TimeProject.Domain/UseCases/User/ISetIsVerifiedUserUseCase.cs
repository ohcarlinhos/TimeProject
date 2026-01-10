using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ISetIsVerifiedUserUseCase
{
    Task<ICustomResult<bool>> Handle(int id, bool isVerified);
}