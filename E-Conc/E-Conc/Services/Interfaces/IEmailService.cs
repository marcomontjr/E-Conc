using System.Threading.Tasks;

namespace E_Conc.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }
}
