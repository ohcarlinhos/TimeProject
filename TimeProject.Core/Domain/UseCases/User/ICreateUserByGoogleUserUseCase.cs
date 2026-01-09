using TimeProject.Core.Application.Dtos.User;
using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, string email);
}