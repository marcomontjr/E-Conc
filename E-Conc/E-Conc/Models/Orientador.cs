using E_Conc.Enum;
using System.Collections.Generic;

namespace E_Conc.Models
{
    public class Orientador
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Produto> Produtos { get; private set; }
        public TipoUsuario tipoUsuario = TipoUsuario.Orientador;
        public TipoUsuario TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
        }

        public Orientador(int id, string nome) : this(nome)
        {
            Id = id;           
        }

        public Orientador(string nome)
        {
            Nome = nome;
        }
    }
}