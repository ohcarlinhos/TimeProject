using Shared.Handlers.Email;

namespace API.Infra.Handlers.Email;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}