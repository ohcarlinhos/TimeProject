using Shared.General;

namespace Core.Auth.UseCases;

public interface ISendRegisterEmailUseCase
{
    public Task<Result<bool>> Handle(string email);
}