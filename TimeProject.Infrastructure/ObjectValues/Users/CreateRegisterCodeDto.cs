using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Pagination.Users;

public class CreateRegisterCodeDto : ICreateRegisterCodeDto
{
    public string? Email { get; set; }
}