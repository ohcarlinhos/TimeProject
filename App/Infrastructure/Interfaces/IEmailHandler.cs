using Shared.Handlers.Email;

namespace App.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}