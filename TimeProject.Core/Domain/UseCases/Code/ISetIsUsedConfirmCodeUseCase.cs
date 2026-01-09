using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}