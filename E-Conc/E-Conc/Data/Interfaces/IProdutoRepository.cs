﻿using E_Conc.Data.Repository.Interfaces;
using E_Conc.Models;
using System.Collections.Generic;

namespace E_Conc.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        List<Produto> GetProdutos();
    }
}