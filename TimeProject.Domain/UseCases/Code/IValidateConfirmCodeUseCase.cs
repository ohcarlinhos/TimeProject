using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface IValidateConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id, string email);
}