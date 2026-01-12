using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserPasswordByEmailUseCase
{
    ICustomResult<IGetUserPasswordByEmailResult> Handle(string email);
}