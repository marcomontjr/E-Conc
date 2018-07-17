using E_Conc.Models.ViewModels;
using System.Threading.Tasks;

namespace E_Conc.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailHelpDesk(ContatoViewModel contato);
    }
}