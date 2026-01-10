using TimeProject.Core.RemoveDependencies.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<Result<UserEntity>> Handle(string provider, string id);
}