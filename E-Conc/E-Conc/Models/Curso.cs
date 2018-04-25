using System;
using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Curso
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }
        public List<Aluno> Alunos { get; private set; }
        public List<Produto> Produtos { get; private set; }        
    }
}