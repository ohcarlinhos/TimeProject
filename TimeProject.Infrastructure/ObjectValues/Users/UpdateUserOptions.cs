using TimeProject.Domain.ObjectValues;

namespace TimeProject.Infrastructure.ObjectValues.Users;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}