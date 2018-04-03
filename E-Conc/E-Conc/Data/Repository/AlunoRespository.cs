using E_Conc.Data.Interfaces;
using E_Conc.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class AlunoRespository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRespository(Contexto context) : base(context) { }

        public List<Aluno> GetAlunos()
        {
            return _context.Alunos.ToList();
        }
    }
}
