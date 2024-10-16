namespace API.Core.User.Utils;

public interface IUpdateUserOptions
{
    public bool SkipOldPasswordCompare { get; set; }
}