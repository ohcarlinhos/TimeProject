using Entities;
using Shared.General;

namespace Core.User.UseCases;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<Result<UserEntity>> Handle(string provider, string id);
}