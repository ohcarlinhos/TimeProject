using TimeProject.Core.Application.Dtos.Handlers.Email;

namespace TimeProject.Api.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}