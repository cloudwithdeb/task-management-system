using System.Net;
using System.Net.Mail;

namespace IMailNamespace;

public interface IMail
{
    public void sendEmail(string message, string subject, string email);
}