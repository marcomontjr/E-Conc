using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class AlunoRespository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRespository(Contexto context, IHttpContextAccessor contextAccessor) 
            : base(context, contextAccessor) { }

        public List<Aluno> GetAlunos()
        {
            return _context.Alunos.ToList();
        }
    }
}