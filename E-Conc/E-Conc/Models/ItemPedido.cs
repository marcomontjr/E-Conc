namespace E_Conc.Models
{
    public class ItemPedido
    {
        public int Id { get; private set; }
        public bool Disponivel { get; private set; }
        public Produto Produto { get; private set; }

        public ItemPedido() { }

        public ItemPedido(int id, bool disponivel, Produto produto) 
            : this(disponivel, produto)
        {
            Id = id;
        }

        public ItemPedido(bool disponivel, Produto produto)
        {
            Produto = produto;
            Disponivel = disponivel;
        }
    }
}