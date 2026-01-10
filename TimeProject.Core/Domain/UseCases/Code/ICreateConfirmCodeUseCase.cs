using TimeProject.Core.Domain.Entities;
using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface ICreateConfirmCodeUseCase
{
    Task<Result<ConfirmCodeEntity>> Handle(int userId, ConfirmCodeType type);
}