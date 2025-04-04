using System.Net.Mail;
using System.Net;
using Azure.Security.KeyVault.Secrets;


public class Email
{
    SmtpClient smtpClient { get; set; }
    int port { get; set; }
    string emailUsername { get; set; }
    string emailPassword { get; set; }

    /// <summary>
    /// creates an email client using the default port of 587 and the office365 smtp provider.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pass"></param>
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
    /// <summary>
    /// creates an email client using the default port of 587.
    /// </summary>
    /// <param name="mailClient"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    public Email(string mailClient, string user, string pass)
    {
        this.emailUsername = user;
        this.emailPassword = pass;
        this.smtpClient = new SmtpClient(mailClient);
        this.port = 587;
        smtpClient.Port = port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    /// <summary>
    /// creates an email client using the default port of 587.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    /// <param name="port"></param>
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
    /// <summary>
    /// Creates an email client using all parameters provided in the constructor arguments
    /// </summary>
    /// <param name="mailClient"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    /// <param name="port"></param>
    public Email(string mailClient, string user, string pass, int port)
    {
        this.emailUsername = user;
        this.emailPassword = pass;
        this.smtpClient = new SmtpClient(mailClient);
        this.port = port;
        smtpClient.Port = port;
        smtpClient.UseDefaultCredentials = false;
        smtpClient.EnableSsl = true;
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.Credentials = new NetworkCredential(emailUsername, emailPassword);
    }
    /// <summary>
    /// Uses email username and password values stored in azure keyvault secrets. If values provided in the args cannot be found in the secret vault
    /// constructor will use the raw string values instead. Uses Officer 365 as the email client and 587 as the default port.
    /// </summary>
    /// <param name="azVault"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
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
    /// <summary>
    /// Uses email username and password values stored in azure keyvault secrets. If values provided in the args cannot be found in the secret vault
    /// constructor will use the raw string values instead. Uses Officer 365 as the email client. Uses the integer value for port provided in the
    /// constructor arguments.
    /// </summary>
    /// <param name="azVault"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    /// <param name="port"></param>
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
    /// Uses email username and password values stored in azure keyvault secrets. If values provided in the args cannot be found in the secret vault
    /// constructor will use the raw string values instead. Uses the default port of 587. Uses the string value for mailClient provided in the
    /// constructor arguments.
    /// </summary>
    /// <param name="azVault"></param>
    /// <param name="mailClient"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    public Email(SecretClient azVault, string mailClient, string user, string pass)
    {
        this.smtpClient = new SmtpClient(mailClient);
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
    /// <summary>
    /// Uses email username and password values stored in azure keyvault secrets. If values provided in the args cannot be found in the secret vault
    /// constructor will use the raw string values instead. All other values are not pulled from azure vault and the constructor instead uses the string
    /// value for mailClient and the integer value for port provided in the constructor arguments.
    /// </summary>
    /// <param name="azVault"></param>
    /// <param name="mailClient"></param>
    /// <param name="user"></param>
    /// <param name="pass"></param>
    /// <param name="port"></param>
    public Email(SecretClient azVault, string mailClient, string user, string pass, int port)
    {
        this.smtpClient = new SmtpClient(mailClient);
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
        smtpClient.Credentials = new NetworkCredential(this.emailUsername, this.emailPassword);
    }
    /// <summary>
    /// send email to recipient in method args
    /// </summary>
    /// <param name="recipient">email message recipient</param>
    /// <param name="subject">email message subject</param>
    /// <param name="body">email message body</param>
    public void sendMessage(string recipient, string subject, string body)
    {
        smtpClient.Send(this.emailUsername, recipient, subject, body);
    }

    /// <summary>
    /// send email to recipient in method args
    /// </summary>
    /// <param name="recipient">email message recipient</param>
    /// <param name="ccAddress">email address to CC message on</param>
    /// <param name="subject">email message subject</param>
    /// <param name="body">email message body</param>
    public void sendMessage(string recipient, string ccAddress, string subject, string body)
    {
        MailAddress to = new MailAddress(recipient);
        MailAddress from = new MailAddress(this.emailUsername);
        MailMessage message = new MailMessage(from, to);
        message.Subject = subject;
        message.Body = body;
        message.CC.Add(ccAddress);
        smtpClient.Send(message);
    }

    /// <summary>
    /// send email to recipient in method args with the body formatted in HTML
    /// </summary>
    /// <param name="recipient">email message recipient</param>
    /// <param name="subject">enail message subject</param>
    /// <param name="body">email message body</param>
    public void sendMessageHtml(string recipient, string subject, string body)
    {
        MailMessage mail = new MailMessage(emailUsername, recipient, subject, body);
        mail.IsBodyHtml = true;
        smtpClient.Send(mail);
    }

}
