using TimeProject.Domain.RemoveDependencies.General;

namespace TimeProject.Domain.UseCases.Code;

public interface IValidateConfirmCodeUseCase
{
    Task<Result<bool>> Handle(string id, string email);
}