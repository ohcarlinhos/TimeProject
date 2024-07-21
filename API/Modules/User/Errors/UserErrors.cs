namespace API.Modules.User.Errors;

public static class UserErrors
{
    public const string NotFound = "user_not_found";
    public const string EmailAlreadyInUse = "email_already_in_use";
    public const string DifferentPassword = "different_password";
    public const string RegisterCodeIsNotAvailable = "register_code_is_not_available";
}