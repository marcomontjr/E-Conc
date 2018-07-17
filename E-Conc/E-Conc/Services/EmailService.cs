using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using E_Conc.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace E_Conc.Services
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            ExecuteEmail(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        public async Task ExecuteEmail(string email, string subject, string message)
        {
            try
            {
                string toEmail = string.IsNullOrEmpty(email)
                                 ? _emailSettings.ToEmail
                                 : email;
                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(_emailSettings.UsernameEmail, "Marco Monteiro Jr. (CEO)")
                };
                mail.To.Add(new MailAddress(toEmail));

                mail.Subject = "E-Conc Relacionamento - " + subject;
                mail.Body = message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, 
                    _emailSettings.PrimaryPort))
                {
                    smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, 
                        _emailSettings.UsernamePassword);

                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }  
        }

        public async Task SendEmailHelpDesk(ContatoViewModel contato)
        {
             try
             {
                 string fromEmail = string.IsNullOrEmpty(contato.Email)
                                 ? contato.Email
                                 : _emailSettings.FromEmail;

                 MailMessage mail = new MailMessage()
                 {
                     From = new MailAddress(fromEmail)
                 };
                 mail.To.Add(new MailAddress("econcrelacionamento@gmail.com"));

                 mail.Body = contato.Message;
                 mail.Subject = contato.Subject;
                 mail.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                 mail.IsBodyHtml = true;
                 mail.Priority = MailPriority.High;

                 using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain,
                         _emailSettings.PrimaryPort))
                 {
                     smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail,
                         _emailSettings.UsernamePassword);

                     smtp.EnableSsl = true;
                     await smtp.SendMailAsync(mail);
                 }
             }
             catch
             {

             }
        }
    }
}