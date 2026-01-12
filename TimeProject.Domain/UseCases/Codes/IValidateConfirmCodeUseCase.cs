using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Codes;

public interface IValidateConfirmCodeUseCase
{
    ICustomResult<bool> Handle(string id, string email);
}