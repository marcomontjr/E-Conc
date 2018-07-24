using E_Conc.Data.Interfaces;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private readonly IItemPedidoRespository _itemPedidoRepo;

        public PedidoController(IProdutoRepository produtoRepo,
                                IItemPedidoRespository itemPedidoRepo)
        {
            _produtoRepo = produtoRepo;
            _itemPedidoRepo = itemPedidoRepo;
        }
        
        [Authorize]
        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue)
                return View(_itemPedidoRepo.AddItemPedido(produtoId.Value));

            return View();
        }

        [Authorize]
        public IActionResult Resumo(int? itemPedidoId)
        {
            if (itemPedidoId.HasValue)
                return View(_itemPedidoRepo.GetById(itemPedidoId.Value));
            
            return View();
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinho(int? itemPedido)
        {
            if (itemPedido.HasValue)
                _itemPedidoRepo.RemoveItemPedido(itemPedido.Value);

            return RedirectToAction("Carrossel");
        }
    }
}