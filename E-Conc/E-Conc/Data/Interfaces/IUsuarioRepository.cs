using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;

namespace E_Conc.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetUsuarioPorEmail(LoginViewModel login);        
    }
}
