namespace App.Infra.Errors;

public static class AuthMessageErrors
{
    public const string WrongEmailOrPassword = "bad_request:wrong_email_or_password";
    public const string SendEmailError = "server_error:send_recovery_email_error";
}