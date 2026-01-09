using TimeProject.Core.Application.General;
using TimeProject.Core.Application.Dtos.User;
using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Core.Domain.Repositories;
using TimeProject.Core.Domain.Utils;
using TimeProject.Core.Domain.UseCases.User;

namespace TimeProject.Api.Modules.User.UseCases;

public class UpdateUserUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserUseCase
{
    public async Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto)
    {
        return await _update(id, dto, null);
    }

    public async Task<Result<UserOutDto>> Handle(int id, UpdateUserDto dto, IUpdateUserOptions config)
    {
        return await _update(id, dto, config);
    }

    private async Task<Result<UserOutDto>> _update(int id, UpdateUserDto dto, IUpdateUserOptions? config)
    {
        var result = new Result<UserOutDto>();
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