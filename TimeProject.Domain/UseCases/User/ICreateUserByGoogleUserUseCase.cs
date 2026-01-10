using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface ICreateUserByGoogleUserUseCase
{
    Task<ICustomResult<Entities.User>> Handle(CreateUserOAtuhDto dto, string email);
}