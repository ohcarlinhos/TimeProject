using API.Core.User;
using API.Database;
using API.Infra.Errors;
using AutoMapper;
using Entities;
using Shared.General;
using Shared.General.Pagination;
using Shared.User;

namespace API.Modules.User.Services;

public class UserServices(IUserRepository userRepository, IMapper mapper) : IUserServices
{
    private List<UserMap> MapData(List<UserEntity> users)
    {
        return mapper.Map<List<UserMap>>(users);
    }

    private UserMap MapData(UserEntity userEntity)
    {
        return mapper.Map<UserMap>(userEntity);
    }

    public Result<Pagination<UserMap>> Index(PaginationQuery paginationQuery)
    {
        var data = MapData(userRepository.Index(paginationQuery));
        var totalItems = userRepository.GetTotalItems(paginationQuery);

        return new Result<Pagination<UserMap>>()
        {
            Data = Pagination<UserMap>.Handle(data, paginationQuery, totalItems)
        };
    }

    public async Task<Result<UserMap>> Details(int id)
    {
        var result = new Result<UserMap>();
        var user = await userRepository.FindById(id);

        return user == null
            ? result.SetError(UserErrors.NotFound)
            : result.SetData(mapper.Map<UserMap>(user));
    }

    public async Task<Result<UserMap>> UpdateRole(int id, UpdateRoleDto dto)
    {
        var result = new Result<UserMap>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserErrors.NotFound);

        if (Enum.TryParse(typeof(UserRole), dto.Role, out var userRole) == false)
        {
            return result.SetError(UserErrors.RoleNotFound);
        }

        user.UserRole = (UserRole)userRole;

        var entity = await userRepository.Update(user);
        result.Data = mapper.Map<UserMap>(entity);
        return result;
    }

    public async Task<Result<UserMap>> UpdatePasswordByEmail(string email, string password)
    {
        var result = new Result<UserMap>();
        var user = await userRepository.FindByEmail(email);

        if (user == null)
            return result.SetError(UserErrors.NotFound);

        user.Password = BCrypt.Net.BCrypt.HashPassword(password);

        var entity = await userRepository.Update(user);
        result.Data = mapper.Map<UserMap>(entity);
        return result;
    }

    public async Task<Result<bool>> Disable(int id, DisableUserDto dto)
    {
        var result = new Result<bool>();
        var user = await userRepository.FindById(id);

        if (user == null)
            return result.SetError(UserErrors.NotFound);

        user.IsActive = dto.IsActive;
        await userRepository.Update(user);

        result.Data = user.IsActive;

        return result;
    }

    public async Task<Result<bool>> Delete(int id)
    {
        return new Result<bool>
        {
            Data = await userRepository.Delete(id)
        };
    }


    public async Task<Result<UserEntity>> FindByEmail(string email)
    {
        var result = new Result<UserEntity>();
        var user = await userRepository.FindByEmail(email);

        return user == null ? result.SetError(UserErrors.NotFound) : result.SetData(user);
    }

    public async Task<Result<UserEntity>> FindById(int id)
    {
        var result = new Result<UserEntity>();
        var user = await userRepository.FindById(id);

        return user == null ? result.SetError(UserErrors.NotFound) : result.SetData(user);
    }

    private async Task<bool> EmailNotAvailability(string email) => await userRepository.FindByEmail(email) != null;
}