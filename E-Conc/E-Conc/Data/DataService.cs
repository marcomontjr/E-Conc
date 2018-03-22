using E_Conc.Enum;
using E_Conc.Interface;
using E_Conc.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Data
{
    public class DataService : IDataService
    {
        private readonly Contexto _contexto;
        public DataService(Contexto contexto)
        {
            _contexto = contexto;
        }

        public List<Produto> GetProdutos()
        {
            return _contexto.Produtos.ToList();
        }

        public void InicializaDB()
        {
            _contexto.Database.Migrate();
            if (_contexto.Produtos.Count() == 0)
            {
                List<Produto> produtos = new List<Produto>
                {
                    new Produto("E-Commerce", "DesenvolvimentoProduto.jpg", Categoria.Desenvolvimento),
                    new Produto("StartUp", "EmpreendedorismoProduto.jpg", Categoria.Empreendedorismo),
                    new Produto("Software BitCoins", "IniciacaoCientificaProduto.jpg", Categoria.IniciacaoCientifica),
                    new Produto("Teste", "IniciacaoCientificaProduto.jpg", Categoria.IniciacaoCientifica)
                };

                Orientador orientador = new Orientador("Marco");
                Curso curso = new Curso("Analise", "ADS");

                foreach (var produto in produtos)
                {
                    _contexto.Produtos
                        .Add(produto);
                
                    _contexto.ItensPedido
                        .Add(new ItemPedido(produto, orientador, curso));
                }

                _contexto.SaveChanges();
            }
        }
    }
}