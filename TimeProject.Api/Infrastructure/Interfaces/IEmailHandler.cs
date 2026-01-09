using Shared.Handlers.Email;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}