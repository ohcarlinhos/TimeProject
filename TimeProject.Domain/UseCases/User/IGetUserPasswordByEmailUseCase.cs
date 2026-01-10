using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.Shared;

namespace TimeProject.Domain.UseCases.User;

public interface IGetUserPasswordByEmailUseCase
{
    Task<ICustomResult<IGetUserPasswordByEmailResult>> Handle(string email);
}