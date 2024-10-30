using Shared.Handlers.Email;

namespace App.Modules.Auth.Utils;

public static class RecoveryEmailFactory
{
    public static EmailPayload Create(string email, string url, DateTime dateLimit)
    {
        return new EmailPayload
        {
            To = email,
            Subject = "Recuperação de Senha - Registra meu tempo aí!",
            Body =
                $@"
                        <p>
                            Você acaba de requisitar a recuperação da sua senha, para prosseguir <a href='{url}' target='_blank'>clique aqui</a> para recria-la. <br/>
                            Ou copie a URL e cole no seu navegador: {url} <br/><br/>
                            Expiração do código: {dateLimit}
                        </p>
                    ",
            IsHtml = true
        };
    }
}