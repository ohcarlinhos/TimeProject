using System.Net;
using System.Net.Mail;
using API.Infrastructure.Settings;

namespace API.Integrations.Smtp;

public class CustomSmtp : ICustomSmtp
{
    private readonly SmtpClient _smtpClient;
    private readonly SmtpSettings _smtpSettings;

    public CustomSmtp(SmtpSettings smtpSettings)
    {
        _smtpSettings = smtpSettings;

        _smtpClient = new SmtpClient();
        _smtpClient.Host = _smtpSettings.Host;
        _smtpClient.Port = _smtpSettings.Port;
        _smtpClient.EnableSsl = true;
        _smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
    }

    public void Send(MailMessage mailMessage)
    {
        mailMessage.From = new MailAddress(_smtpSettings.Username);
        _smtpClient.Send(mailMessage);
    }
}