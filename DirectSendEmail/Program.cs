using System.Configuration;
using System.Net.Mail;


        var eTo = ConfigurationManager.AppSettings["emailTo"];
        var eFrom = ConfigurationManager.AppSettings["emailFrom"];
        var eHost = ConfigurationManager.AppSettings.Get("emailHost");
        int ePort = Convert.ToInt32(ConfigurationManager.AppSettings.Get("emailPort"));

        MailMessage alert = new MailMessage();
        alert.To.Add(new MailAddress(eTo));
        alert.From = new MailAddress(eFrom);
        alert.Subject = "Email Direct Send";
        alert.Body = "Demo of email direct send. <br/> Direct send requires no username or password. <br/> <br/> Direct send does however require the public IP address to be in the dmaain SPF record. <br/>";
        alert.IsBodyHtml = true;

        SmtpClient mail = new SmtpClient();
        mail.Port = ePort;
        mail.Host = eHost;
        mail.EnableSsl = true;
        mail.Send(alert);
