using Shared.Handlers.Email;

namespace API.Infra.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}