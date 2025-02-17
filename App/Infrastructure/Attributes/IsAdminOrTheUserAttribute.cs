namespace App.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class IsAdminOrTheUserAttribute(bool ignoreAdmin = false) : Attribute
{
    public readonly bool IgnoreAdmin = ignoreAdmin;
};
