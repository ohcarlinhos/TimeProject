using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ISendRegisterEmailUseCase
{
    public Task<Result<bool>> Handle(string email, string verifyUrl);
}