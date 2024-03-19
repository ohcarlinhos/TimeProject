namespace API.Infrastructure;

public static class EnvConfig
{
    public static void Load(string path)
    {
        // se o arquivo não existir
        if (!File.Exists(path)) return;

        // loop no arquivo importado por linha
        foreach (var line in File.ReadAllLines(path))
        {
            // separando as strings
            var parts = line.Split('=', StringSplitOptions.RemoveEmptyEntries);

            // queremos apenas linhas que criam arrays de dois itens 
            if (parts.Length != 2) continue;

            // Registramos nossas variáveis no ambiente
            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}