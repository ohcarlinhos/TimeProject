using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.User;

public interface IDeleteUserUseCase
{
    Task<Result<bool>> Handle(int id);
}