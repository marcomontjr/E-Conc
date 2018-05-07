using System.Linq;
using System.Threading.Tasks;
using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }        

        public Usuario GetUsuarioPorEmail(LoginViewModel login)
        {
            return _context.Usuarios
                .Where(u => u.Email == login.Email)
                .Where(u => u.Senha == login.Senha)
                .Single();
        }

        public async Task<IdentityResult> RegistrarNovoUsuario(Usuario novoUsuario, 
            UserManager<Usuario> userManager)
        {
            var result = await userManager.CreateAsync(novoUsuario, novoUsuario.Senha);

            return result;
        }
    }
}