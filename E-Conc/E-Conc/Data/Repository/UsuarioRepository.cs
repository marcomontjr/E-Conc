using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Http;

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
                .Single();
        }
    }
}