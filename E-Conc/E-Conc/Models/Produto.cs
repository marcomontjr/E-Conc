using E_Conc.Enum;
using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; private set; }
        public string Arquivo { get; private set; }
        public bool Disponivel { get; private set; }
        public string Descricao { get; private set; }
        public List<Requisito> Requisitos { get; private set; }
        public Categoria Categoria { get; private set; }
        public Usuario Usuario { get; private set; }
        public Curso Curso { get; private set; }

        public Produto() { }

        public Produto
            (int id, string nome, string arquivo, bool disponivel, string descricao, List<Requisito> requisitos, Categoria categoria, Usuario usuario, Curso curso) 
            : this(nome, arquivo, disponivel, descricao, requisitos, categoria, usuario, curso)
        {
            Id = id;            
        }

        public Produto
            (string nome, string arquivo, bool disponivel, string descricao, List<Requisito> requisitos, Categoria categoria, Usuario usuario, Curso curso)
        {
            Nome = nome;
            Arquivo = arquivo;
            Disponivel = disponivel;
            Descricao = descricao;
            Requisitos = requisitos;
            Categoria = categoria;
            Usuario = usuario;
            Curso = curso;
        }     
    }
}