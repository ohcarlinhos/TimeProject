using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface ISetIsUsedConfirmCodeUseCase
{
    Task<ICustomResult<bool>> Handle(string id);
}