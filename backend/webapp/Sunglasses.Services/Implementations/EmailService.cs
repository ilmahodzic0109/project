using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService
{
    private readonly string smtpServer = "smtp.gmail.com";  
    private readonly int smtpPort = 587;  
    private readonly string smtpUser = "ilmahodzic7@gmail.com";  
    private readonly string smtpPassword = "iksn rgvq tbab tmrh";

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
        try
        {
            var fromEmail = new MailAddress(smtpUser);
            var toAddress = new MailAddress(toEmail);

            var message = new MailMessage(fromEmail, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            using (var smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);
                smtpClient.EnableSsl = true;
                await smtpClient.SendMailAsync(message);
            }
        }
        catch (Exception ex)
        {
         
            Console.WriteLine($"Error sending email: {ex.Message}");
        }
    }
}
