using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class CreateRegisterCodeDto : ICreateRegisterCodeDto
{
    public string? Email { get; set; }
}