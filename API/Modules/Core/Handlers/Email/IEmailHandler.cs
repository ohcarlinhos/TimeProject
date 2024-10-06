using Shared.Handlers.Email;

namespace API.Modules.Core.Handlers.Email;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}