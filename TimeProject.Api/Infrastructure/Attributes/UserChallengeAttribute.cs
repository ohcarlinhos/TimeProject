namespace TimeProject.Api.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class UserChallengeAttribute(bool ignoreAdmin = false) : Attribute
{
    public readonly bool IgnoreAdmin = ignoreAdmin;
}