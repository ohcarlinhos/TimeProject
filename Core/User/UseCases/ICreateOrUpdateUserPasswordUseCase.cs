using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto);
}