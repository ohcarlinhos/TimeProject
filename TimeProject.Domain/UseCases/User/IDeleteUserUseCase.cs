using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.User;

public interface IDeleteUserUseCase
{
    Task<Result<bool>> Handle(int id);
}