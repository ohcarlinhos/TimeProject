using TimeProject.Infrastructure.ObjectValues;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Repositories;
using TimeProject.Domain.UseCases.Users;
using TimeProject.Infrastructure.Utils.Interfaces;
using TimeProject.Domain.Dtos.Users;
using TimeProject.Domain.Shared;
using TimeProject.Infrastructure.Errors;
using TimeProject.Infrastructure.ObjectValues.Users;

namespace TimeProject.Application.UseCases.Users;

public class UpdateUserUseCase(IUserRepository repository, IUserMapDataUtil mapper) : IUpdateUserUseCase
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
        var user = repository.FindById(id);

        if (user == null) return result.SetError(UserMessageErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Email) && user.Email != dto.Email && config?.UpdateFromAdmin == true)
        {
            var emailAvailable = repository.EmailIsAvailable(dto.Email);
            if (emailAvailable == false) return result.SetError(UserMessageErrors.EmailAlreadyInUse);

            user.Email = dto.Email;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && user.Name != dto.Name) user.Name = dto.Name;

        if (!string.IsNullOrEmpty(dto.Timezone)) user.Timezone = dto.Timezone;

        var entity = repository.Update(user);

        result.Data = mapper.Handle(entity);
        return result;
    }
}