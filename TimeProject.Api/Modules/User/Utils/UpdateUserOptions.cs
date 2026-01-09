using TimeProject.Core.Domain.Utils;

namespace TimeProject.Api.Modules.User.Utils;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}