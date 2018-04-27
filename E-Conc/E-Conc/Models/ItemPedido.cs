namespace E_Conc.Models
{
    public class ItemPedido : BaseModel
    {
        public Usuario Usuario { get; private set; }
        public Produto Produto { get; set; }

        public ItemPedido(int id, Produto produto, Usuario usuario) : this(produto, usuario)
        {
            Id = id;
        }

        public ItemPedido(Produto produto, Usuario usuario)
        {
            Produto = produto;
            Usuario = usuario;
        }
    }
}