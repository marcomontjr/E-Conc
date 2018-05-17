using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private readonly IItemPedidoRespository _itemPedidoRepo;
        private CarrosselViewModel _carrosselViewModel;

        public PedidoController(IProdutoRepository produtoRepo,
                                IItemPedidoRespository itemPedidoRepo)
        {
            _produtoRepo = produtoRepo;
            _itemPedidoRepo = itemPedidoRepo;
        }

        [Authorize]
        public IActionResult Carrossel()
        {
            var produtosDesenvolvimento = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Desenvolvimento));

            var produtosEmpreendedorismo = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Empreendedorismo));

            var produtosIniciacaoCientifica = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.IniciacaoCientifica));

            var produtosPesquisaAcademica = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.PesquisaAcademica));

            CategoriaViewModel[] _categoriaViewModel = new CategoriaViewModel[]
            {
                produtosDesenvolvimento,
                produtosEmpreendedorismo,
                produtosIniciacaoCientifica,
                produtosPesquisaAcademica
            };
            
            _carrosselViewModel = new CarrosselViewModel(_categoriaViewModel);

            return View(_carrosselViewModel);
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
                return View(_itemPedidoRepo.GetItemPedidoById(itemPedidoId.Value));
            
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