using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }      
        [Required]
        public Produto Produto { get; private set; }
        //[Required]
        //public Aluno Solicitante { get; private set; }

        public ItemPedido(Produto produto/*, Aluno aluno*/)
        {
            Produto = produto;
            //Solicitante = aluno;
        }
    }
}