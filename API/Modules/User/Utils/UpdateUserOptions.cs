using Core.User.Utils;

namespace App.Modules.User.Utils;

public class UpdateUserOptions : IUpdateUserOptions
{
    public bool SkipOldPasswordCompare { get; set; }
}