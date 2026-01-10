using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Code;

public interface ISetWasSentConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, bool wasSent = true);
}