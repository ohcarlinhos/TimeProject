using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ISendRegisterEmailUseCase
{
    public Task<ICustomResult<bool>> Handle(string email, string verifyUrl);
}