using API.Modules.Shared;
using API.Modules.User.DTO;
using API.Modules.User.Entities;
using API.Modules.User.Errors;
using API.Modules.User.Models;
using API.Modules.User.Repositories;
using AutoMapper;

namespace API.Modules.User.Services;

public class UserServices(IUserRepository userRepository, IMapper mapper) : IUserServices
{
    public async Task<Result<UserDto>> Get(int id)
    {
        var result = new Result<UserDto>();
        var entity = await userRepository.FindById(id);
        return result.SetData(mapper.Map<UserDto>(entity));
    }

    public async Task<Result<UserDto>> Create(CreateUserModel model)
    {
        var result = new Result<UserDto>();

        if (await EmailNotAvailability(model.Email))
        {
            result.Message = UserErrors.EmailAlreadyInUse;
            result.HasError = true;
            return result;
        }

        var entity = await userRepository
            .Create(new Entities.User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            });

        result.Data = mapper.Map<UserDto>(entity);

        return result;
    }

    public async Task<Result<UserDto>> Update(int id, UpdateUserModel model)
    {
        var result = new Result<UserDto>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(model.Email) && user.Email != model.Email)
        {
            if (await EmailNotAvailability(model.Email))
                return result.SetError(UserErrors.EmailAlreadyInUse);

            user.Email = model.Email;
        }

        if (!string.IsNullOrWhiteSpace(model.Name) && user.Name != model.Name) 
            user.Name = model.Name;

        if (!string.IsNullOrWhiteSpace(model.Password))
        {
            if (model.OldPassword != user.Password)
                return result.SetError(UserErrors.DifferentPassword);

            user.Password = model.Password;
        }

        var entity = await userRepository.Update(user);

        result.Data = mapper.Map<UserDto>(entity);
        return result;
    }

    public async Task<Result<bool>> Delete(int id)
    {
        return new Result<bool>
        {
            Data = await userRepository.Delete(id)
        };
    }

    private async Task<bool> EmailNotAvailability(string email) => await userRepository.FindByEmail(email) != null;
}