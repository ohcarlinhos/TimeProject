using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IGetUserByOAtuhProviderIdUseCase
{
    Task<Result<UserEntity>> Handle(string provider, string id);
}