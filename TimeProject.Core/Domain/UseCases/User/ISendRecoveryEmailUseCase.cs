using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ISendRecoveryEmailUseCase
{
    Task<Result<bool>> Handle(string email);
}