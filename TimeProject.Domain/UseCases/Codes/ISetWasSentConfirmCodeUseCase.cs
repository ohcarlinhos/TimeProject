using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Codes;

public interface ISetWasSentConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id, bool wasSent = true);
}