using System.Net.Mail;
using API.Integrations.Smtp;
using Shared.Handlers.Email;

namespace API.Handlers.Email;

public class EmailHandler(ICustomSmtp customSmtp) : IEmailHandler
{
    public void Send(EmailPayload emailPayload)
    {
        var mailMessage = new MailMessage();

        mailMessage.To.Add(new MailAddress(emailPayload.To));
        mailMessage.Subject = string.IsNullOrEmpty(emailPayload.Subject) ? "Default Subject" : emailPayload.Subject;
        mailMessage.Body = string.IsNullOrEmpty(emailPayload.Body) ? "Default Body" : emailPayload.Body;
        mailMessage.IsBodyHtml = emailPayload.IsHtml;
        customSmtp.Send(mailMessage);
    }
}