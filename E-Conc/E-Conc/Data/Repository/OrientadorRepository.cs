using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class OrientadorRepository : Repository<Orientador>, IOrientadorRepository
    {
        public OrientadorRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public List<Orientador> GetOrientadores()
        {
            return _context.Orientadores.ToList();
        }
    }
}