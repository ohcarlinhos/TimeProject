using Shared.General;

namespace API.Core.Codes.UseCases;

public interface ISetWasSentConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, bool wasSent = true);
}