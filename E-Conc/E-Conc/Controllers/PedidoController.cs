using E_Conc.Data.Repository.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private List<CategoriaViewModel> _categoriaViewModel = new List<CategoriaViewModel>();
        private CarrosselViewModel _carrosselViewModel;
        public PedidoController(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }
        public IActionResult Carrossel()
        {
            List<Produto> produtos = _produtoRepo.GetProdutos();

            _categoriaViewModel.Add(new CategoriaViewModel(Categoria.Desenvolvimento, produtos));

            _carrosselViewModel = new CarrosselViewModel(_categoriaViewModel);

            return View(_carrosselViewModel);
        }

        //public IActionResult Carrinho()
        //{
        //    return View();
        //}        

        //public IActionResult Resumo()
        //{
        //    return View();
        //}
    }
}