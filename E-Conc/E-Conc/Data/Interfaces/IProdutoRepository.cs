﻿using E_Conc.Data.Repository.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using System.Collections.Generic;

namespace E_Conc.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        List<Produto> GetProdutosPorCategoria(Categoria categoria);
        Produto AdicionaProduto(Produto produto);
        void RemoveProduto(int? produtoId);
        List<Produto> GetProdutosPorUsuario(Usuario usuario);
        List<Produto> GetProdutosDisponiveis(Usuario usuario);
        List<Produto> GetProdutosComprados();
    }
}