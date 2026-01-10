using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<ICustomResult<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<ICustomResult<bool>> Handle(int userId, UpdatePasswordDto dto);
    public Task<ICustomResult<bool>> Handle(int userId, UpdateByAdminPasswordDto dto);
}