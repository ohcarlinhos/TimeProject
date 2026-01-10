using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Code;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id);
}