using System.Net.Mail;
using System.Net;
using Azure.Security.KeyVault.Secrets;


public class Email
{
    SmtpClient smtpClient { get; set; }
    int port { get; set; }
    string emailUsername { get; set; }
    string emailPassword { get; set; }

    public Email(string user, string pass)
    {
        this.emailUsername = user;
        this.emailPassword = pass;
        this.smtpClient = new SmtpClient("smtp.office365.com");
        this.port = 587;
        smtpClient.Port = port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    public Email(string user, string pass, int port)
    {
        this.emailUsername = user;
        this.emailPassword = pass;
        this.smtpClient = new SmtpClient("smtp.office365.com");
        this.port = port;
        smtpClient.Port = port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    public Email(SecretClient azVault, string user, string pass)
    {
        this.smtpClient = new SmtpClient("smtp.office365.com");
        this.port = 587;
        smtpClient.Port = this.port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            KeyVaultSecret sec = azVault.GetSecret(user);
            this.emailUsername = sec.Value;
        }
        catch
        {
            this.emailUsername = user;
        }
        try
        {
            KeyVaultSecret sec = azVault.GetSecret(pass);
            this.emailPassword = sec.Value;
        }
        catch
        {
            this.emailPassword = pass;
        }
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    public Email(SecretClient azVault, string user, string pass, int port)
    {
        this.smtpClient = new SmtpClient("smtp.office365.com");
        this.port = port;
        smtpClient.Port = this.port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        try
        {
            KeyVaultSecret sec = azVault.GetSecret(user);
            this.emailUsername = sec.Value;
        }
        catch
        {
            this.emailUsername = user;
        }
        try
        {
            KeyVaultSecret sec = azVault.GetSecret(pass);
            this.emailPassword = sec.Value;
        }
        catch
        {
            this.emailPassword = pass;
        }
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    /// <summary>
    /// send email to recipient in method args
    /// </summary>
    /// <param name="recipient">email message recipient</param>
    /// <param name="subject">enail message subject</param>
    /// <param name="body">email message body</param>
    public void sendMessage(string recipient, string subject, string body)
    {
        smtpClient.Send(emailUsername, recipient, subject, body);
    }

}
