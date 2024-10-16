using API.Core.User.Utils;

namespace API.Modules.User.Utils;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool SkipOldPasswordCompare { get; set; }
}