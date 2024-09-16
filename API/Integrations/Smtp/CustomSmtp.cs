using System.Net;
using System.Net.Mail;

namespace API.Integrations.Smtp;

public class CustomSmtp : ICustomSmtp
{
    private readonly SmtpClient _smtpClient;
    private readonly IConfiguration _configuration;

    public CustomSmtp(IConfiguration configuration)
    {
        _configuration = configuration;

        _smtpClient = new SmtpClient();
        _smtpClient.Host = configuration["Smtp:Host"]!;
        _smtpClient.Port = int.Parse(configuration["Smtp:Port"]!);
        _smtpClient.EnableSsl = true;
        _smtpClient.Credentials =
            new NetworkCredential(configuration["Smtp:Username"]!, configuration["Smtp:Password"]!);
    }

    public void Send(MailMessage mailMessage)
    {
        mailMessage.From = new MailAddress(_configuration["Smtp:Username"]!);
        _smtpClient.Send(mailMessage);
    }
}