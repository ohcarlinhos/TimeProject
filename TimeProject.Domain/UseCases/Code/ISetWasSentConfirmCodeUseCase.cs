using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface ISetWasSentConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id, bool wasSent = true);
}