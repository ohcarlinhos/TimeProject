using TimeProject.Domain.Dtos.Users;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class DisableUserDto : IDisableUserDto
{
    public bool IsActive { get; set; }
}