using TimeProject.Core.Application.General;

namespace TimeProject.Core.Domain.UseCases.Code;

public interface IValidateConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, string email);
}