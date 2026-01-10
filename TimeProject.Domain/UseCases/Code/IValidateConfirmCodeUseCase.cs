using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface IValidateConfirmCodeUseCase
{
    Task<ICustomResult<bool>> Handle(string id, string email);
}