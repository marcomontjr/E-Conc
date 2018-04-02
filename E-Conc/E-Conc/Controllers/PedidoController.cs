using E_Conc.Data.Repository.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private List<CategoriaViewModel> _categoriaViewModel = new List<CategoriaViewModel>();
        private CarrosselViewModel _carrosselViewModel;
        private ItemPedido _itemPedido;
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

        public IActionResult Carrinho()
        {
            List<Produto> produtos = _produtoRepo.GetProdutos();
            var produto = produtos.First();
            var orientador = new Orientador(1, "Marco Jr.");
            var curso = new Curso(1, "Análise de Sistemas", "ADS");
            produto.Orientador = orientador;
            produto.Curso = curso;
            _itemPedido = new ItemPedido(true, produto);
            return View(_itemPedido);
        }

        public IActionResult Resumo()
        {
            List<Produto> produtos = _produtoRepo.GetProdutos();
            var produto = produtos.First();
            var orientador = new Orientador(1, "Marco Jr.");
            var curso = new Curso(1, "Análise de Sistemas", "ADS");
            produto.Orientador = orientador;
            produto.Curso = curso;
            _itemPedido = new ItemPedido(true, produto);

            var aluno = new Aluno(1, "Marco", "123456789", "José Crespo Gonzáles", "FATEC-SO", curso, "email@email.com");            

            var resumoViewModel = new ResumoViewModel(_itemPedido, aluno);

            return View(resumoViewModel);
        }
    }
}