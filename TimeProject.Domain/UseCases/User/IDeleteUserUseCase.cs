using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IDeleteUserUseCase
{
    Task<ICustomResult<bool>> Handle(int id);
}