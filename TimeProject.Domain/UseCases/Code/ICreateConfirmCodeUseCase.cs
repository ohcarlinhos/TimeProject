using TimeProject.Domain.Entities;
using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Code;

public interface ICreateConfirmCodeUseCase
{
    Task<Result<ConfirmCode>> Handle(int userId, ConfirmCodeType type);
}