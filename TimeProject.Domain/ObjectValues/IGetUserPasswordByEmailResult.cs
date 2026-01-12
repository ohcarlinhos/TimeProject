using TimeProject.Domain.Entities;

namespace TimeProject.Domain.ObjectValues;

public interface IGetUserPasswordByEmailResult
{
    IUserPassword UserPassword { get; set; }
    IUser User { get; set; }
}