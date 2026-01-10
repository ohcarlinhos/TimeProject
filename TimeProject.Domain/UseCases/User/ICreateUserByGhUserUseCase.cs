using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.Dtos.User;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public record EmailGh(string Email, bool Primary, bool Verified);

public interface ICreateUserByGhUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserOAtuhDto dto, IEnumerable<EmailGh> emails);
}