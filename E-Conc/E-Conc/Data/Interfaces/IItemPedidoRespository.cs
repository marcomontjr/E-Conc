using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;

namespace E_Conc.Data.Interfaces
{
    public interface IItemPedidoRespository : IRepository<ItemPedido>
    {
        ItemPedido AddItemPedido(int produtoId);
        ItemPedido GetItemPedidoById(int itemPedidoId);
    }
}
