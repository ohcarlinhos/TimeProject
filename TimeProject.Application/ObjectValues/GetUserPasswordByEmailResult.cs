using TimeProject.Domain.Entities;
using TimeProject.Infrastructure.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.UseCases.Users;

namespace TimeProject.Application.ObjectValues;

public class GetUserPasswordByEmailResult : IGetUserPasswordByEmailResult
{
    public IUserPassword UserPassword { get; set; } = null!;
    public IUser User { get; set; } = null!;
}