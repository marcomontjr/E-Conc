using E_Conc.Models;
using System.Collections.Generic;

namespace E_Conc.Data.Repository.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        List<Produto> GetProdutos();
    }
}