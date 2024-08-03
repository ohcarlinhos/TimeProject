using API.Database;
using API.Modules.Shared;
using API.Modules.User.Errors;
using API.Modules.User.Repositories;
using AutoMapper;
using Shared;
using Shared.User;

namespace API.Modules.User.Services;

public class UserServices(IUserRepository userRepository, IMapper mapper, ProjectContext dbContext) : IUserServices
{
    public async Task<Result<UserMap>> Get(int id)
    {
        var result = new Result<UserMap>();
        var entity = await userRepository.FindById(id);
        return result.SetData(mapper.Map<UserMap>(entity));
    }

    public async Task<Result<UserMap>> Create(CreateUserDto dto)
    {
        var result = new Result<UserMap>();
        var registerCode = await dbContext.RegisterCodes.FindAsync(dto.RegisterCode);

        if (registerCode == null || registerCode.IsUsed)
        {
            result.Message = UserErrors.RegisterCodeIsNotAvailable;
            result.HasError = true;
            return result;
        }

        if (await EmailNotAvailability(dto.Email))
        {
            result.Message = UserErrors.EmailAlreadyInUse;
            result.HasError = true;
            return result;
        }

        var hasPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        var entity = await userRepository
            .Create(new Entities.User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = hasPassword
            });

        // lógica de validação de código de registro.
        registerCode.IsUsed = true;
        registerCode.UserId = entity.Id;
        dbContext.RegisterCodes.Update(registerCode);
        await dbContext.SaveChangesAsync();

        result.Data = mapper.Map<UserMap>(entity);

        return result;
    }

    public async Task<Result<UserMap>> Update(int id, UpdateUserDto dto)
    {
        var result = new Result<UserMap>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserErrors.NotFound);

        if (!string.IsNullOrWhiteSpace(dto.Email) && user.Email != dto.Email)
        {
            if (await EmailNotAvailability(dto.Email))
                return result.SetError(UserErrors.EmailAlreadyInUse);

            user.Email = dto.Email;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && user.Name != dto.Name)
            user.Name = dto.Name;

        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            if (!BCrypt.Net.BCrypt.Verify(dto.OldPassword, user.Password))
                return result.SetError(UserErrors.DifferentPassword);

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
        }

        var entity = await userRepository.Update(user);

        result.Data = mapper.Map<UserMap>(entity);
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