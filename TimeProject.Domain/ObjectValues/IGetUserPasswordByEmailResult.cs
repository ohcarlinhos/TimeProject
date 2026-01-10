using TimeProject.Domain.Entities;

namespace TimeProject.Domain.ObjectValues;

public interface IGetUserPasswordByEmailResult
{
    UserPassword UserPassword { get; set; }
    Entities.User User { get; set; }
}