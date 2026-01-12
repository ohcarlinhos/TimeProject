using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Codes;

public interface ISetIsUsedConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id);
}