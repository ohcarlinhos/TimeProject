using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.RemoveDependencies.Dtos.User;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdateByAdminPasswordDto dto);
}