using System.Net;
using System.Net.Mail;
using TimeProject.Api.Infrastructure.Interfaces;
using TimeProject.Api.Infrastructure.Settings;

namespace TimeProject.Api.Infrastructure.Integrations;

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
        _smtpClient.EnableSsl = false;
        _smtpClient.Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password);
    }

    public void Send(MailMessage mailMessage)
    {
        mailMessage.From = new MailAddress(_smtpSettings.Email);
        _smtpClient.Send(mailMessage);
    }
}