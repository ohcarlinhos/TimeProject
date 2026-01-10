using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdateByAdminPasswordDto dto);
}