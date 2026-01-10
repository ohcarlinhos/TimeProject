using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<Result<UserEntity>> Handle(string provider, string id);
}