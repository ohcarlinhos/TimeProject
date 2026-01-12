using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Infrastructure.Entities.Enums;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.Codes;

public interface ICreateConfirmCodeUseCase
{
    ICustomResult<IConfirmCode> Handle(int userId, ConfirmCodeType type);
}