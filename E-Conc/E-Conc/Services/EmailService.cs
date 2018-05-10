using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using E_Conc.Services.Interfaces;

namespace E_Conc.Services
{
    public class EmailService : IEmailService
    {
        private readonly string EMAIL_ORIGEM = "monteirojr.marco@gmail.com";
        private readonly string EMAIL_SENHA = "senha";
        public async Task SendAsync(string to, string subject, string body)
        {
            using (var mensagemDeEmail = new MailMessage())
            {
                mensagemDeEmail.From = new MailAddress(EMAIL_ORIGEM);

                mensagemDeEmail.Subject = subject;
                mensagemDeEmail.To.Add(to);
                mensagemDeEmail.Body = body;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.UseDefaultCredentials = true;
                    smtpClient.Credentials = new NetworkCredential(EMAIL_ORIGEM, EMAIL_SENHA);

                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;

                    smtpClient.Timeout = 20_000;

                    await smtpClient.SendMailAsync(mensagemDeEmail);
                }
            }
        }
    }
}   