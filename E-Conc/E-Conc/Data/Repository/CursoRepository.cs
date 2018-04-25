using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(Contexto context, IHttpContextAccessor contextAccessor) 
            : base(context, contextAccessor) { }

        public List<Curso> GetCursos()
        {
            return _context.Cursos.ToList();
        }
    }
}