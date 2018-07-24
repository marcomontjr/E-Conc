using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private CarrosselViewModel _carrosselViewModel;

        public ProdutoController(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
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
        public IActionResult Detalhes(int? produtoId)
        {
            if (produtoId != null)
            {
                var produto = _produtoRepo.GetById(produtoId);
                return View(produto);
            }
            else
            {
                return RedirectToAction("Pedido", "Carrossel");
            }
        }

        [Authorize]
        public IActionResult VerTudo()
        {
            List<Produto> Produtos = _produtoRepo.GetAll().ToList();

            return View(Produtos);
        }

        [Authorize]
        public IActionResult Comprados()
        {
            return View();
        }
    }
}