using Shared.Handlers;
using Shared.Handlers.Email;

namespace API.Handlers.Email;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}