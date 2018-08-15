using System;
using System.Collections.Generic;
using System.Linq;
using E_Conc.Data.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E_Conc.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(Contexto context, IHttpContextAccessor contextAccessor)
            : base(context, contextAccessor) { }

        public new Produto GetById(int? produtoId)
        {
            var produto = (from p in _context.Produtos
                            .Include(u => u.Usuario)
                            where p.Id.Equals(produtoId)
                            select p).Single();           

            if (produto != null)
                return produto;

            throw new Exception("Produto não Encontrado");
        }

        public List<Produto> GetProdutosPorCategoria(Categoria categoria)
        {
            return _context.Produtos
                           .Where(c => c.Categoria == categoria)
                           .ToList();
        }

        public new IEnumerable<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public Produto AdicionaProduto(Produto produto)
        {
            if (produto != null)
            {
                _context.Produtos.Add(produto);

                var produtoLog = new ProdutoLog(produto, "Produto Cadastrado", DateTime.Now);

                _context.ProdutoLog.Add(produtoLog);
                _context.SaveChanges();
                _context.Dispose();
            }

            return produto;
        }

        public void RemoveProduto(int? produtoId)
        {
            if (produtoId.HasValue)
            {
                var produto = _context.Produtos
                                .Where(p => p.Id.Equals(produtoId))
                                .FirstOrDefault();

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                _context.Dispose();
            }
        }

        public List<Produto> GetProdutosPorUsuario(Usuario usuario)
        {
            return _context.Produtos
                        .Where(p => p.Usuario.Equals(usuario)).ToList();
        }

        public List<Produto> GetProdutosDisponiveisPorUsuario(Usuario usuario)
        {
            return _context.Produtos
                        .Where(u => u.Usuario == usuario && u.Disponivel)
                        .ToList();
        }

        public List<Produto> GetProdutosComprados()
        {
            return _context.Produtos
                        .Where(u => !u.Disponivel)
                        .ToList();
        }

        public new void Update(Produto produto)
        {
            if (produto != null)
            {
                var productToUpdate = _context.Produtos
                                    .Where(p => p.Id == produto.Id)
                                    .Single();

                produto.Usuario = productToUpdate.Usuario;

                if (productToUpdate != null)
                {
                    productToUpdate.Arquivo = produto.Arquivo;
                    productToUpdate.Categoria = produto.Categoria;
                    productToUpdate.Curso = produto.Curso;
                    productToUpdate.Descricao = produto.Descricao;
                    productToUpdate.Nome = produto.Nome;
                    productToUpdate.Requisitos = produto.Requisitos;                    

                    _context.SaveChanges();
                    _context.Dispose();
                }
                else
                    throw new ArgumentNullException("Produto Não Existe");
            }
        }

        public void UpdateDispProduto(int? produtoId)
        {
            if (produtoId != null)
            {
                var productToUpdate = _context.Produtos
                                    .Where(p => p.Id == produtoId)
                                    .Single();

                if (productToUpdate.Disponivel)
                    productToUpdate.Disponivel = false;
                else
                    productToUpdate.Disponivel = true;
            }
        }

        public List<Produto> GetProdutosCompradosPorUsuario(Usuario usuario)
        {
            return _context.Produtos
                        .Where(u => u.Usuario == usuario && !u.Disponivel)
                        .ToList();
        }
    }
}