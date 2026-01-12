using TimeProject.Api.Infrastructure.Errors;
using TimeProject.Application.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.User;

public class UpdateUserUseCase(IUserRepository repo, IUserMapDataUtil mapper) : IUpdateUserUseCase
{
    public ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto)
    {
        return _update(id, dto, null);
    }

    public ICustomResult<IUserOutDto> Handle(int id, IUpdateUserDto dto, IUpdateUserOptions config)
    {
        return _update(id, dto, config);
    }

    private ICustomResult<IUserOutDto> _update(int id, IUpdateUserDto dto, IUpdateUserOptions? config)
    {
        var result = new CustomResult<IUserOutDto>();
        var user = repo.FindById(id);

        if (user == null) return result.SetError(UserMessageErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Email) && user.Email != dto.Email && config?.UpdateFromAdmin == true)
        {
            var emailAvailable = repo.EmailIsAvailable(dto.Email);
            if (emailAvailable == false) return result.SetError(UserMessageErrors.EmailAlreadyInUse);

            user.Email = dto.Email;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && user.Name != dto.Name) user.Name = dto.Name;

        if (dto.Utc.HasValue) user.Utc = dto.Utc.Value;

        var entity = repo.Update(user);

        result.Data = mapper.Handle(entity);
        return result;
    }
}