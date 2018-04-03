using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private CategoriaViewModel _categoriaViewModel;
        private CarrosselViewModel _carrosselViewModel;
        public PedidoController(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }
        public IActionResult Carrossel()
        {
            var produtosDesenvolvimento = new CategoriaViewModel(Categoria.Desenvolvimento, 
                _produtoRepo.GetProdutosPorCategoria(Categoria.Desenvolvimento));

            var produtosEmpreendedorismo = new CategoriaViewModel(Categoria.Empreendedorismo,
                _produtoRepo.GetProdutosPorCategoria(Categoria.Empreendedorismo));

            var produtosIniciacaoCientifica = new CategoriaViewModel(Categoria.IniciacaoCientifica, 
                _produtoRepo.GetProdutosPorCategoria(Categoria.IniciacaoCientifica));

            var produtosPesquisaAcademica = new CategoriaViewModel(Categoria.PesquisaAcademica, 
                _produtoRepo.GetProdutosPorCategoria(Categoria.PesquisaAcademica));

            IList<CategoriaViewModel> categoriasCarrossel = new List<CategoriaViewModel>()
            {
                produtosDesenvolvimento,
                produtosEmpreendedorismo,
                produtosIniciacaoCientifica,
                produtosPesquisaAcademica
            };
            
            _carrosselViewModel = new CarrosselViewModel(categoriasCarrossel);

            return View(_carrosselViewModel);
        }

        public IActionResult Carrinho()
        {     
            return View();
        }

        public IActionResult Resumo()
        {            
            return View();
        }
    }
}