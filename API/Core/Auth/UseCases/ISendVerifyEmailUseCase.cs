using Shared.General;

namespace API.Core.Auth.UseCases;

public interface ISendVerifyEmailUseCase
{
    public Task<Result<bool>> Handle(string email);
}