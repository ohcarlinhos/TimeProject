namespace App.Infra.Errors;

public static class TimePeriodMessageErrors
{
    public const string EndDateIsBiggerThenStartDate = "bad_request:end_date_is_bigger_then_start_date";
    public const string NotFound = "not_found:time_period_not_found";
}
