﻿using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        #region Propriedades
        private readonly IProdutoRepository _produtoRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IProdutoLogRepository _produtoLogRepo;
        private UserManager<Usuario> _userManager;
        private CarrosselViewModel _carrosselViewModel;
        #endregion

        #region Construtor
        public ProdutoController(IProdutoRepository produtoRepo,
                                 IUsuarioRepository usuarioRepo,
                                 IProdutoLogRepository produtoLogRepo,
                                 UserManager<Usuario> userManager)
        {
            _produtoRepo = produtoRepo;
            _userManager = userManager;
            _usuarioRepo = usuarioRepo;
            _produtoLogRepo = produtoLogRepo;
        }
        #endregion

        #region Acesso a Administradores, Orientadores e Alunos
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult Carrossel()
        {
            var produtosDesenvolvimento = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Desenvolvimento));

            var produtosEmpreendedorismo = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Empreendedorismo));

            var produtosIniciacaoCientifica = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Iniciacao_Cientifica));

            var produtosPesquisaAcademica = new CategoriaViewModel
                (_produtoRepo.GetProdutosPorCategoria(Categoria.Pesquisa_Academica));

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

        [Authorize(Roles = "Admin, Orientador, Aluno")]
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

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult VerTudo()
        {
            List<Produto> Produtos = _produtoRepo.GetAll().ToList();

            return View(Produtos);
        }

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult Historico(int produtoId)
        {
            var produtoLog = _produtoLogRepo.GetByIdProduto(produtoId);

            if (produtoLog != null)
                return View(produtoLog);
            else
                return View("SemHistorico");
            
        }
        #endregion

        #region Acesso a Administradores e Orientadores   


        [Authorize(Roles = "Admin, Orientador")]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Authorize(Roles = "Admin, Orientador")]
        public IActionResult Editar(int? produtoId)
        {
            var produtoToUpdate = _produtoRepo.GetById(produtoId);            

            return View(produtoToUpdate);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador")]
        public IActionResult Editar(Produto produto)
        {
            produto.Arquivo = AtribuiNomeArquivo(produto.Categoria);

            if (produto != null)            
                _produtoRepo.Update(produto);

            return View("Resumo", produto);            
        }

        [Authorize(Roles = "Admin, Orientador")]
        public IActionResult RemoverProduto(int? produtoId)
        {
            if (produtoId.HasValue)
                _produtoRepo.RemoveProduto(produtoId);

            return RedirectToAction("MeusProdutos");
        }
        #endregion

        #region Acesso a Administradores
        [Authorize(Roles = "Admin")]
        public IActionResult TodosComprados()
        {
            List<Produto> produtos = _produtoRepo.GetProdutosComprados();

            return View("MeusProdutos", produtos);
        }
        #endregion

        #region Acesso a Orientadores
        [Authorize(Roles = "Orientador")]
        public IActionResult MeusProdutos()
        {
            Usuario usuario = AtribuiUsuarioCorrente();

            List<Produto> produtos = _produtoRepo.GetProdutosPorUsuario(usuario);

            return View(produtos);
        }

        [HttpPost]
        [Authorize(Roles = "Orientador")]
        public IActionResult Cadastrar(Produto produto)
        {
            Produto novoProduto = new Produto
            {
                Nome = produto.Nome,
                Arquivo = AtribuiNomeArquivo(produto.Categoria),
                Descricao = produto.Descricao,
                Disponivel = true,
                Categoria = produto.Categoria,
                Curso = produto.Curso,
                Usuario = AtribuiUsuarioCorrente(),
                Requisitos = produto.Requisitos
            };

            return View("Resumo", _produtoRepo.AdicionaProduto(novoProduto));
        }

        [Authorize(Roles = "Orientador")]
        public IActionResult Disponiveis()
        {
            Usuario usuario = AtribuiUsuarioCorrente();

            List<Produto> produtos = _produtoRepo.GetProdutosDisponiveisPorUsuario(usuario);

            return View(produtos);
        }

        [Authorize(Roles = "Orientador")]
        public IActionResult Comprados()
        {
            Usuario usuario = AtribuiUsuarioCorrente();

            List<Produto> produtos = _produtoRepo.GetProdutosCompradosPorUsuario(usuario);

            return View(produtos);
        }

        [Authorize(Roles = "Orientador")]
        public IActionResult FinalizarProjeto(int? produtoId)
        {
            var produto = _produtoRepo.GetById(produtoId);

            var finalizacaoProjeto = 
                new FinalizarProjetoViewModel(produto, produto.Id, "", true);

            return View(finalizacaoProjeto);
        }

        [HttpPost]
        [Authorize(Roles = "Orientador")]
        public IActionResult FinalizarProjeto(FinalizarProjetoViewModel finalizarProjeto)
        {
            var produto = _produtoRepo.GetById(finalizarProjeto.ProdutoId);

            finalizarProjeto.Produto = produto;

            _produtoRepo.UpdateDispProduto(produto.Id, finalizarProjeto.DeveSerDisponibilizado);

            var produtoLog = new ProdutoLog(produto, finalizarProjeto.InformacoesProjeto, DateTime.Now);
            _produtoLogRepo.Create(produtoLog);

            return RedirectToAction("MeusProdutos");
        }
        #endregion

        #region MétodosAuxiliares
        private Usuario AtribuiUsuarioCorrente()
        {
            var usuarioEmail = _userManager.FindByEmailAsync(User.Identity.Name);
            return _usuarioRepo.GetUsuarioByEmail(usuarioEmail.Result.Email);
        }

        private string AtribuiNomeArquivo(Categoria categoria)
        {
            if (categoria.Equals(Categoria.Desenvolvimento))
                return "Desenvolvimento.jpg";
            else if (categoria.Equals(Categoria.Empreendedorismo))
                return "Empreendedorismo.jpg";
            else if (categoria.Equals(Categoria.Iniciacao_Cientifica))
                return "Iniciacao_Cientifica.jpg";
            else if (categoria.Equals(Categoria.Pesquisa_Academica))
                return "Pesquisa_Academica.jpg";

            return string.Empty;
        }
        #endregion
    }
}