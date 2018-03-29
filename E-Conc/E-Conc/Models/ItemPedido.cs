namespace E_Conc.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public Orientador Orientador { get; private set; }
        public Curso Curso { get; private set; }

        public ItemPedido() { }

        public ItemPedido(int id, Produto produto, Orientador orientador, Curso curso) 
            : this(produto, orientador, curso)
        {
            Id = id;
        }

        public ItemPedido(Produto produto, Orientador orientador, Curso curso)
        {
            Produto = produto;
            Orientador = orientador;
            Curso = curso;
        }
    }
}