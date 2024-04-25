namespace API.Modules.Periodo;

public static class PeriodoErrors
{
    public static readonly string DataFinalMaiorQueInicial =
        "bad_request: A data final do período deve ser maior que a inicial.";

    public static readonly string NaoEncontrado =
        "not_found: Não foi possível encontrar um período com esse id.";
    
    public static readonly string RegistroIdValido = 
        "É necessário informar um registro id válido para cadastrar um período.";
}
