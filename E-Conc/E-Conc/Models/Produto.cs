using E_Conc.Enum;
using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public bool Disponivel { get; set; }
        public string Descricao { get; set; }
        public string Requisitos { get; set; }
        public Categoria Categoria { get; set; }
        public Usuario Usuario { get; set; }
        public Curso Curso { get; set; }

        public Produto() { }

        public Produto
            (int id, string nome, string arquivo, bool disponivel, string descricao, string requisitos, Categoria categoria, Usuario usuario, Curso curso) 
            : this(nome, arquivo, disponivel, descricao, requisitos, categoria, usuario, curso)
        {
            Id = id;            
        }

        public Produto
            (string nome, string arquivo, bool disponivel, string descricao, string requisitos, Categoria categoria, Usuario usuario, Curso curso)
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