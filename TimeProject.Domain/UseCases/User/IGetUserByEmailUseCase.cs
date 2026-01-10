using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserByEmailUseCase
{
    Task<Result<Entities.User>> Handle(string email);
}