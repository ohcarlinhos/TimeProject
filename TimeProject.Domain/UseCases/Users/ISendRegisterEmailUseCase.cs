using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Users;

public interface ISendRegisterEmailUseCase
{
    public ICustomResult<bool> Handle(string email, string verifyUrl);
}