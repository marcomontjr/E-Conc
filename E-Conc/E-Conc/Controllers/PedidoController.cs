using E_Conc.Data.Interfaces;
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
        private CategoriaViewModel _categoriaViewModel;
        public PedidoController(IProdutoRepository produtoRepo)
        {
            _produtoRepo = produtoRepo;
        }
        public IActionResult Carrossel()
        {
            var produtosDesenvolvimento = _produtoRepo.GetProdutosPorCategoria(Categoria.Desenvolvimento);
            var produtosEmpreendedorismo = _produtoRepo.GetProdutosPorCategoria(Categoria.Empreendedorismo);
            var produtosIniciacaoCientifica = _produtoRepo.GetProdutosPorCategoria(Categoria.IniciacaoCientifica);
            var produtosPesquisaAcademica = _produtoRepo.GetProdutosPorCategoria(Categoria.PesquisaAcademica);

            _categoriaViewModel = new CategoriaViewModel(produtosDesenvolvimento, produtosEmpreendedorismo,
                                                        produtosIniciacaoCientifica, produtosPesquisaAcademica);


            return View(_categoriaViewModel);
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