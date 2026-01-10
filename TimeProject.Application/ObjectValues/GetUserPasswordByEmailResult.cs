using TimeProject.Domain.Entities;
using TimeProject.Domain.ObjectValues;
using TimeProject.Domain.UseCases.User;

namespace TimeProject.Application.ObjectValues;

public class GetUserPasswordByEmailResult : IGetUserPasswordByEmailResult
{
    public UserPassword UserPassword { get; set; } = null!;
    public Domain.Entities.User User { get; set; } = null!;
}