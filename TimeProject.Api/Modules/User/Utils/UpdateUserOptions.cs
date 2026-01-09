using Core.User.Utils;

namespace TimeProject.Api.Modules.User.Utils;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool UpdateFromAdmin { get; set; }
}