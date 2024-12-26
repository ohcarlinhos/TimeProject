using Shared.General;

namespace Core.User.UseCases;

public interface ISendRegisterEmailUseCase
{
    public Task<Result<bool>> Handle(string email);
}