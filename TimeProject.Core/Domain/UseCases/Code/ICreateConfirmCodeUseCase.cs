using TimeProject.Core.Application.General;
using TimeProject.Core.Domain.Entities;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface ICreateConfirmCodeUseCase
{
    Task<Result<ConfirmCodeEntity>> Handle(int userId, ConfirmCodeType type);
}