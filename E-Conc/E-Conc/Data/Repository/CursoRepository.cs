using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;

namespace E_Conc.Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(Contexto context, IHttpContextAccessor contextAccessor) 
            : base(context, contextAccessor) { }

        public new Curso GetById(int? produtoId)
        {
            return null;
        }
    }
}