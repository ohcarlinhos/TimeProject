using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class GetUserPasswordByEmailResult : IGetUserPasswordByEmailResult
{
    public IUserPassword UserPassword { get; set; } = null!;
    public IUser User { get; set; } = null!;
}