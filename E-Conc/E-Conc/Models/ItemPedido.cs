namespace E_Conc.Models
{
    public class ItemPedido : BaseModel
    {
        public Pedido Pedido { get; private set; }
        public Produto Produto { get; set; }

        public ItemPedido(int id, Pedido pedido, Produto produto) : this(pedido, produto)
        {
            Id = id;
        }

        public ItemPedido(Pedido pedido, Produto produto)
        {
            Produto = produto;
            Pedido = pedido;
        }
    }
}