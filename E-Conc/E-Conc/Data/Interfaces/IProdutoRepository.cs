﻿using E_Conc.Data.Repository.Interfaces;
using E_Conc.Enum;
using E_Conc.Models;
using System.Collections.Generic;

namespace E_Conc.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Produto GetProdutoById(int? produtoId);
        List<Produto> GetProdutos();
        List<Produto> GetProdutosPorCategoria(Categoria categoria);
    }
}