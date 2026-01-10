using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdateByAdminPasswordDto dto);
}