using System.Net;
using System.Net.Mail;
using IMailNamespace;

namespace MailNamespace;

public class Mail : IMail
{
    private readonly IConfiguration _config;
    public Mail(IConfiguration config)
    {
        _config=config;
    }

    public void sendEmail(string message, string subject, string email)
    {
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(_config.GetConnectionString("EMAIL"));
        mail.To.Add(email);
        mail.Subject = subject;
        mail.Body = message;
        mail.IsBodyHtml = false;

        SmtpClient smtp = new SmtpClient();
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.UseDefaultCredentials = false;
        smtp.Host = "smtp.gmail.com";
        smtp.Credentials = new NetworkCredential(_config.GetConnectionString("EMAIL"),_config.GetConnectionString("EMAIL_PASSWORD"));
        smtp.Send(mail);
    }
}