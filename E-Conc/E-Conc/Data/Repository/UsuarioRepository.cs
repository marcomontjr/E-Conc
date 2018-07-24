using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;

namespace E_Conc.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public new Usuario GetById(int? usuarioId)
        {
            return _context.Usuarios
                    .Where(u => u.Id == usuarioId.ToString())
                    .Single();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return _context.Usuarios
                .Where(u => u.Email == email)
                .Single();
        }
    }
}