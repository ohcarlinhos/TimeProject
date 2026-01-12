using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public record EmailGh(string Email, bool Primary, bool Verified);

public interface ICreateUserByGhUserUseCase
{
    Task<ICustomResult<IUser>> Handle(CreateUserOAtuhDto dto, IEnumerable<EmailGh> emails);
}