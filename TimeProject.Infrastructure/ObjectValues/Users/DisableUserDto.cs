using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class DisableUserDto : IDisableUserDto
{
    public bool IsActive { get; set; }
}