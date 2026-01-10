using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.User;
using TimeProject.Domain.Utils;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Application.UseCases.User;

public class UpdateUserUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserUseCase
{
    public async Task<ICustomResult<UserOutDto>> Handle(int id, UpdateUserDto dto)
    {
        return await _update(id, dto, null);
    }

    public async Task<ICustomResult<UserOutDto>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config)
    {
        return await _update(id, dto, config);
    }

    private async Task<ICustomResult<UserOutDto>> _update(int id, UpdateUserDto dto, IUpdateUserOptions? config)
    {
        var result = new CustomResult<UserOutDto>();
        var user = await repo.FindById(id);

        if (user == null) return result.SetError(UserMessageErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Email) && user.Email != dto.Email && config?.UpdateFromAdmin == true)
        {
            var emailAvailable = await repo.EmailIsAvailable(dto.Email);
            if (emailAvailable == false) return result.SetError(UserMessageErrors.EmailAlreadyInUse);

            user.Email = dto.Email;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && user.Name != dto.Name) user.Name = dto.Name;

        if (dto.Utc.HasValue) user.Utc = dto.Utc.Value;

        var entity = await repo.Update(user);

        result.Data = mapper.Handle(entity);
        return result;
    }
}