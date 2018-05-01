using E_Conc.Data.Interfaces;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace E_Conc.Data.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRespository
    {
        public ItemPedidoRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public ItemPedido AddItemPedido(int produtoId)
        {
            var produto = (from p in _context.Produtos
                            .Include(u => u.Usuario)
                            .Include(c => c.Curso)
                           where p.Id.Equals(produtoId)
                           select p).Single();

            //TODO: Implementar a Busca do Aluno para a realização da compra. Passar o Aluno buscado como segundo
            //parâmetro do ItemPedido

            if (produto != null)
            {
                if (!_context.ItensPedido
                    .Where(ip => ip.Produto.Id == produto.Id)
                    .Any())
                {
                    var itemPedido = new ItemPedido(produto, produto.Usuario);
                    _context.ItensPedido.Add(itemPedido);

                    _context.SaveChanges();

                    return itemPedido;
                }
                else
                    throw new ArgumentNullException("Já Existe um Pedido para este Item");
            }
            else
                throw new ArgumentNullException("Produto Não Encontrado");
        }
    }
}