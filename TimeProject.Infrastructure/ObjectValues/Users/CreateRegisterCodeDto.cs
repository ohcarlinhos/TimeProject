using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class CreateRegisterCodeDto : ICreateRegisterCodeDto
{
    public string? Email { get; set; }
}