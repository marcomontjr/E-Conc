using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Aluno
    {
        public int Ra { get; private set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }
        public List<Curso> Curso { get; private set; }
        public string Email { get; private set; }

        public Aluno(int ra, string nome, string telefone, string instituicao, string instituicaoSigla, 
            List<Curso> curso, string email)
        {
            Ra = ra;
            Nome = nome;
            Telefone = telefone;
            Instituicao = instituicao;
            InstituicaoSigla = instituicaoSigla;
            Curso = curso;
            Email = email;
        }
    }
}
