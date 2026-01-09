using TimeProject.Core.Application.General;
using TimeProject.Core.Application.Dtos.User;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateOrUpdateUserPasswordUseCase
{
    public Task<Result<bool>> Handle(int userId, CreatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdatePasswordDto dto);
    public Task<Result<bool>> Handle(int userId, UpdateByAdminPasswordDto dto);
}