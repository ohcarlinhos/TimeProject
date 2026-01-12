using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    ICustomResult<IUser> Handle(string provider, string id);
}