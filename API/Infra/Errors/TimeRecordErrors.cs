namespace API.Infra.Errors;

public static class TimeRecordErrors
{
    public const string NotFound = "not_found:time_record_not_found";
    public const string AlreadyInUse = "bad_request:time_record_code_already_in_use";
    public const string CategoryNotFound = "bad_request:category_not_found";
    public const string CodeMustValue = "bad_request:time_record_code_must_value";
    public const string CodeAlreadyInUse = "bad_request:time_record_code_already_in_use";
}