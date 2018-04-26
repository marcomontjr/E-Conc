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

        //public ItemPedido AddItemPedido(int produtoId)
        //{           
        //    var produto = (from p in _context.Produtos
        //                .Include(o => o.Orientador)
        //                .Include(c => c.Curso)
        //                 where p.Id.Equals(produtoId)
        //                 select p).Single();

        //    //TODO: Implementar a Busca do Aluno para a realização da compra.

        //    if (produto != null)
        //    {
        //        //int? pedidoId = GetSessionPedidoId();

        //        //var pedido = _context.Pedidos
        //        //    .Where(p => p.Id == pedidoId)
        //        //    .SingleOrDefault();

        //        //if (pedido == null)
        //        //    pedido = new Pedido();

        //        //if (!_context.ItensPedido
        //        //    .Where(i => i.Pedido.Id == pedido.Id
        //        //        && i.Produto.Id.Equals(produtoId))
        //        //    .Any())
        //        //{
        //        //    var itemPedido = new ItemPedido(pedido, produto);
        //        //    _context.ItensPedido.Add(itemPedido);

        //        //    _context.SaveChanges();

        //        //    SetSessionPedidoId(pedido);

        //        //    return itemPedido;
        //        }
        //        else
        //            throw new ArgumentNullException("Já Existe um Pedido para este Item");
        //    }
        //    else
        //        throw new ArgumentNullException("Produto Não Encontrado");
        //}

        private void SetSessionPedidoId()
        {
            
        }

        private int? GetSessionPedidoId()
        {
            return _contextAccessor.HttpContext
            .Session.GetInt32("pedidoId");
        }

        //public ItemPedido GetItensPedidos()
        //{
        //    var pedidoId = GetSessionPedidoId();
        //    var pedido = _context.Pedidos
        //        .Where(p => p.Id == pedidoId)
        //        .Single();

        //    return _context.ItensPedido
        //           .Where(i => i.Pedido.Id == pedido.Id).First();
        //}
    }
}