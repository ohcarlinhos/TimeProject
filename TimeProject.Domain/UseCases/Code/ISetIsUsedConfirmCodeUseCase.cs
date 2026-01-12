using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface ISetIsUsedConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id);
}