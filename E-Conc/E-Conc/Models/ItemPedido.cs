using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }      
        [Required]
        public Produto Produto { get; private set; }
        [Required]
        public Aluno Solicitante { get; private set; }

        public ItemPedido() { }

        public ItemPedido(int id, bool disponivel, Produto produto, Aluno aluno) 
            : this(disponivel, produto, aluno)
        {
            Id = id;
        }

        public ItemPedido(bool disponivel, Produto produto, Aluno aluno)
        {
            Produto = produto;
            Solicitante = aluno;
        }
    }
}