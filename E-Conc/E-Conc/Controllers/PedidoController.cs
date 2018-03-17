using E_Conc.Models;
using E_Conc.Models.ViewModels;
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
            new Produto(4, "Teste de Carrinho", "DesenvolvimentoProduto.jpg", "Desenvolvimento")
        };
        
        Orientador orientador = new Orientador(1, "Marco Jr.");
        Curso curso = new Curso(1, "Análise e Desenvolvimento de Sistemas", "ADS");        

        public IActionResult Carrossel()
        {
            CarrosselViewModel viewModel = new CarrosselViewModel(produtos);
            return View(viewModel);
        }

        public IActionResult Carrinho()
        {
            ItemPedido itemCarrinho = new ItemPedido(4, produtos[0], orientador, curso);
            return View(itemCarrinho);
        }        

        public IActionResult Resumo()
        {
            Aluno aluno = new Aluno(1, "Marco", "12345", "José Crespo", "Fatec-SO", curso, "marco@email.com");
            ItemPedido itemCarrinho = new ItemPedido(4, produtos[0], orientador, curso);
            ResumoViewModel resumo = new ResumoViewModel(produtos[0], itemCarrinho, aluno, curso);
            return View(resumo);
        }
    }
}