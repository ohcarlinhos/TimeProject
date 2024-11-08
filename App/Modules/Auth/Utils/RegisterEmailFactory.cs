using Shared.Handlers.Email;

namespace App.Modules.Auth.Utils;

public static class RegisterEmailFactory
{
    public static EmailPayload Create(string email, string url, string dateLimit)
    {
        return new EmailPayload
        {
            To = email,
            Subject = "Confirmação de E-mail - Registra meu tempo aí!",
            Body =
                $@"
                        <p>
                            Bem vindo(a) ao Registra meu tempo aí! Para utilizar nossa ferramenta, verifique seu email <a href='{url}' target='_blank'>clicando aqui</a>.<br/>
                            Ou copie a URL e cole no seu navegador: {url} <br/><br/>
                            Válido até: {dateLimit}
                        </p>
                ",
            IsHtml = true
        };
    }
}