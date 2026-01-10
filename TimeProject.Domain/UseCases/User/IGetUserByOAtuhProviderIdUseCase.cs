using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<ICustomResult<Entities.User>> Handle(string provider, string id);
}