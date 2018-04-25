using System;

namespace E_Conc.Models
{
    public class ItemPedido
    {
        public Guid Id { get; set; }    
        public Produto Produto { get; set; }

        public ItemPedido(Produto produto)
        {
            Produto = produto;
        }
    }
}