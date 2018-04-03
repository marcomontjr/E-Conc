using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public List<Aluno> Alunos { get; private set; }
        public List<Produto> Produtos { get; private set; }

        public Curso(int id, string nome, string sigla, List<Aluno> alunos, List<Produto> produtos) 
            : this(nome, sigla, alunos, produtos)
        {
            Id = id;            
        }

        public Curso(string nome, string sigla, List<Aluno> alunos, List<Produto> produtos)
        {
            Nome = nome;
            Sigla = sigla;
            Alunos = alunos;
            Produtos = produtos;
        }
    }
}