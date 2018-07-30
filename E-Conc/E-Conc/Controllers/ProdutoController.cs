using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        private readonly IUsuarioRepository _usuarioRepo;
        private UserManager<Usuario> _userManager;
        private CarrosselViewModel _carrosselViewModel;

        public ProdutoController(IProdutoRepository produtoRepo,
                                 IUsuarioRepository usuarioRepo,
                                 UserManager<Usuario> userManager)
        {
            _produtoRepo = produtoRepo;
            _userManager = userManager;
            _usuarioRepo = usuarioRepo;
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

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
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
            else if (categoria.Equals(Categoria.IniciacaoCientifica))
                return "IniciacaoCientifica.jpg";
            else if (categoria.Equals(Categoria.PesquisaAcademica))
                return "PesquisaAcademica.jpg";

            return string.Empty;
        }

        [Authorize]
        public IActionResult RemoverProduto(int? produtoId)
        {
            if (produtoId.HasValue)
                _produtoRepo.RemoveProduto(produtoId);

            return RedirectToAction("MeusProdutos");
        }

        [Authorize]
        public IActionResult MeusProdutos()
        {
            Usuario usuario = AtribuiUsuarioCorrente();

            List<Produto> produtos = _produtoRepo.GetProdutosPorUsuario(usuario);

            return View(produtos);
        }

        [Authorize]
        public IActionResult Comprados()
        {
            Usuario usuario = AtribuiUsuarioCorrente();

            List<Produto> produtos = _produtoRepo.GetProdutosDisponiveis(usuario);

            return View("MeusProdutos", produtos);
        }
    }
}