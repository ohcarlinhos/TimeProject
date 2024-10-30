using System.Net.Mail;

namespace App.Infra.Interfaces;

public interface ICustomSmtp
{ 
    void Send(MailMessage mailMessage);
}