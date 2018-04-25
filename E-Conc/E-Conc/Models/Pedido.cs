namespace E_Conc.Models
{
    public class Pedido : BaseModel
    {
        public ItemPedido Item { get; private set; }
        public Pedido()
        {

        }
    }
}