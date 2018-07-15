using System.Threading.Tasks;

namespace E_Conc.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailSuporte(string name, string email, string subject, string message);
    }
}