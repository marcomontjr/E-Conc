using E_Conc.Enum;

namespace E_Conc.Models
{
    public class Produto : BaseModel
    {
        public string Nome { get; set; }
        public string Arquivo { get; set; }
        public bool Disponivel { get; set; }
        public Categoria Categoria { get; set; }
        public Usuario Usuario { get; set; }

        public Produto() { }

        public Produto(int id, string nome, string arquivo, bool disponivel, Categoria categoria, Usuario usuario) 
            : this(nome, arquivo, disponivel, categoria, usuario)
        {
            Id = id;            
        }

        public Produto(string nome, string arquivo, bool disponivel, Categoria categoria, Usuario usuario)
        {
            Nome = nome;
            Arquivo = arquivo;
            Disponivel = disponivel;
            Categoria = categoria;
            Usuario = usuario;
        }        
    }
}