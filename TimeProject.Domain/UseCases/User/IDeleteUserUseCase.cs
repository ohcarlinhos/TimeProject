using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IDeleteUserUseCase
{
    Task<CustomResult<bool>> Handle(int id);
}