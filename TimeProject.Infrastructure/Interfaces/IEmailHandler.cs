using TimeProject.Infrastructure.Handlers;
using TimeProject.Infrastructure.ObjectValues.Emails;

namespace TimeProject.Infrastructure.Interfaces;

public interface IEmailHandler
{
    public void Send(EmailPayload emailPayload);
}