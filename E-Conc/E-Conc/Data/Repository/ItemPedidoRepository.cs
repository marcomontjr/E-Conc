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

        public ItemPedido AddItemPedido(int produtoId, Usuario comprador)
        {
            var produto = (from p in _context.Produtos
                            .Include(u => u.Usuario)
                           where p.Id.Equals(produtoId)
                           select p).Single();  

            if (produto != null)
            {
                if (!_context.ItensPedido
                    .Where(ip => ip.Produto.Id == produto.Id)
                    .Any())
                {
                    var itemPedido = new ItemPedido(produto, comprador);
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

        public new ItemPedido GetById(int? itemPedidoId)
        {
            var itemPedido = (from ip in _context.ItensPedido
                              .Include(u => u.Usuario)
                              .Include(p => p.Produto)
                              where ip.Id == itemPedidoId
                              select ip).Single();

            if (itemPedido != null)
            {
                GravaLogProdutoComprado(itemPedido.Produto);
                return itemPedido;
            }

            throw new ArgumentNullException("Pedido Não Encontrado");
        }

        public void GravaLogProdutoComprado(Produto produto)
        {
            var produtoLog = new ProdutoLog(produto, "Produto Comprado", DateTime.Now);            

            _context.ProdutoLog.Add(produtoLog);
            _context.SaveChanges();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            var itemPedido = _context.ItensPedido
                .Where(ip => ip.Id.Equals(itemPedidoId))
                .First();

            _context.ItensPedido.Remove(itemPedido);
            _context.SaveChanges();
        }
    }
}