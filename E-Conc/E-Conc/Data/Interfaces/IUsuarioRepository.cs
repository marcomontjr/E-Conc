using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using System.Threading.Tasks;

namespace E_Conc.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetUsuarioPorEmail(LoginViewModel login);
        Task<Usuario> RegistrarNovoUsuario(Usuario usuario);
    }
}
