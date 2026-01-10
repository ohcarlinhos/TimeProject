using TimeProject.Domain.Entities;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Code;

public interface ICreateConfirmCodeUseCase
{
    Task<ICustomResult<ConfirmCode>> Handle(int userId, ConfirmCodeType type);
}