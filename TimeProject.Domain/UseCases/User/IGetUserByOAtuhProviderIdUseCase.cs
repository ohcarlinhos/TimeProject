using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<Result<Entities.User>> Handle(string provider, string id);
}