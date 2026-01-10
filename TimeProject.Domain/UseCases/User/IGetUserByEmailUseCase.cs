using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByEmailUseCase
{
    Task<ICustomResult<Entities.User>> Handle(string email);
}