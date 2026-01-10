using TimeProject.Core.RemoveDependencies.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}