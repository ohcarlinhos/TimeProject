using Shared.General;

namespace Core.Auth.UseCases;

public interface ISendVerifyEmailUseCase
{
    public Task<Result<bool>> Handle(string email);
}