using TimeProject.Domain.ObjectValues;

namespace TimeProject.Application.ObjectValues;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}