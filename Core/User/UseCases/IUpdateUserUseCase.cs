using Core.User.Utils;
using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public interface IUpdateUserUseCase
{
    Task<Result<UserMap>> Handle(int id, UpdateUserDto dto);
    Task<Result<UserMap>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config);
}