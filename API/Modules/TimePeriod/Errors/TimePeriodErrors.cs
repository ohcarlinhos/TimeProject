namespace API.Modules.TimePeriod.Errors;

public static class TimePeriodErrors
{
    public const string EndDateIsBiggerThenStartDate = "bad_request: A data final do timePeriod deve ser maior que a inicial.";
    public const string NotFound = "not_found: Não foi possível encontrar um timePeriod com esse id.";
    public const string WrongTimeRecordId = "É necessário informar um timeRecordId válido para cadastrar um período.";
}
