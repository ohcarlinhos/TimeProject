using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface ISendRegisterEmailUseCase
{
    public Task<Result<bool>> Handle(string email, string verifyUrl);
}