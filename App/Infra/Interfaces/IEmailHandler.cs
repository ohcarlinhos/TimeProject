using Shared.Handlers.Email;

namespace App.Infra.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}