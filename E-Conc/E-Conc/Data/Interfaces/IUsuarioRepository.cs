using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace E_Conc.Data.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario GetUsuarioPorEmail(LoginViewModel login);
        Task<IdentityResult> RegistrarNovoUsuario(Usuario usuario, UserManager<Usuario> userManager);
    }
}
