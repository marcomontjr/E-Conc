namespace E_Conc.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public Produto Produto { get; private set; }
        public Orientador Orientador { get; private set; }
        public Curso Curso { get; private set; }

        public ItemPedido(int id, Produto produto, Orientador orientador, Curso curso)
        {
            Id = id;
            Produto = produto;
            Orientador = orientador;
            Curso = curso;
        }
    }
}
