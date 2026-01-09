using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface ISetWasSentConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, bool wasSent = true);
}