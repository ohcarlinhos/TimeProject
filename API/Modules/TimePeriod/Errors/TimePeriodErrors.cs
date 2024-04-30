namespace API.Modules.TimePeriod.Errors;

public static class TimePeriodErrors
{
    public static readonly string EndDateIsBiggerThenStartDate =
        "bad_request: A data final do período deve ser maior que a inicial.";

    public static readonly string NotFound =
        "not_found: Não foi possível encontrar um período com esse id.";
    
    public static readonly string WrongTimeRecordId = 
        "É necessário informar um registro id válido para cadastrar um período.";
}
