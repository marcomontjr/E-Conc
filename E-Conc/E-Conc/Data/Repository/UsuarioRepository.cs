using System.Linq;
using System.Threading.Tasks;
using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        public async Task<Usuario> RegistrarNovoUsuario(Usuario novoUsuario)
        {
            var userStore = new UserStore<Usuario>(_context);
            var userManager = new UserManager<Usuario>(userStore, null, null, null, null, null, null, null, null);

            await userManager.CreateAsync(novoUsuario, novoUsuario.Senha);

            return novoUsuario;
        }
    }
}