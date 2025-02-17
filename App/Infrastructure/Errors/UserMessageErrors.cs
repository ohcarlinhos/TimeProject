namespace App.Infrastructure.Errors;

public static class UserMessageErrors
{
    public const string NotFound = "not_found:user_not_found";
    public const string EmailAlreadyInUse = "bad_request:email_already_in_use";
    public const string DifferentPassword = "bad_request:different_password";
    public const string RoleNotFound = "bad_request:role_not_found";
    public const string PasswordNotAllowed = "bad_request:password_not_allowed";
}