using E_Conc.Data.Interfaces;
using E_Conc.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(Contexto context) : base(context) { }

        public List<Curso> GetCursos()
        {
            return _context.Cursos.ToList();
        }
    }
}
