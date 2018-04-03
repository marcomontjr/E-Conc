using E_Conc.Data.Interfaces;
using E_Conc.Models;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRespository
    {
        public ItemPedidoRepository(Contexto context) : base(context) { }

        public List<ItemPedido> GetItensPedidos()
        {
            return _context.ItensPedido.ToList();
        }
    }
}