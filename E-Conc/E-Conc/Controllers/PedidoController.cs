using E_Conc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {     
        List<Produto> produtos = new List<Produto>
        {
            new Produto(0, "E-Commerce", "DesenvolvimentoProduto.jpg", "Desenvolvimento"),
            new Produto(1, "StartUp", "EmpreendedorismoProduto.jpg", "Empreendedorismo"),
            new Produto(2, "Software BitCoins", "IniciacaoCientificaProduto.jpg", "Iniciação Cientifica"),
            new Produto(3, "História da Computação", "PesquisaAcademicaProduto.jpg", "Pesquisa Acadêmica")
        };
        
        Orientador orientador = new Orientador("Marco Jr.");
        Curso curso = new Curso("Análise e Desenvolvimento de Sistemas", "ADS");

        public IActionResult Carrossel()
        {
            return View(produtos);
        }

        public IActionResult Carrinho()
        {
            var itemCarrinho = new ItemPedido(1, produtos[0], orientador, curso);           

            return View(itemCarrinho);
        }

        public IActionResult Resumo()
        {
            return View();
        }
    }
}