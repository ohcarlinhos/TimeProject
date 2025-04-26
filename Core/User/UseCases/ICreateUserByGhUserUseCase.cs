using Entities;
using Shared.General;
using Shared.User;

namespace Core.User.UseCases;

public record EmailGh(string Email, bool Primary, bool Verified);

public interface ICreateUserByGhUserUseCase
{
    Task<Result<UserEntity>> Handle(CreateUserGhDto dto, IEnumerable<EmailGh> emails);
}