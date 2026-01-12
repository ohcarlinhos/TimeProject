using TimeProject.Domain.RemoveDependencies.Dtos.User;

namespace TimeProject.Infrastructure.ObjectValues.User;

public class DisableUserDto : IDisableUserDto
{
    public bool IsActive { get; set; }
}