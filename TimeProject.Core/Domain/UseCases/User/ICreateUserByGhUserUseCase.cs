using TimeProject.Core.RemoveDependencies.Dtos.User;
using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public record EmailGh(string Email, bool Primary, bool Verified);

public interface ICreateUserByGhUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, IEnumerable<EmailGh> emails);
}