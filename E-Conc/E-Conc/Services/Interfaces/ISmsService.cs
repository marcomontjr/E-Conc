using System.Threading.Tasks;

namespace E_Conc.Services.Interfaces
{
    public interface ISmsService
    {
        Task SendSmsAsync(string number, string message);
    }
}