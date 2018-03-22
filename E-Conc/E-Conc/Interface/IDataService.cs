using E_Conc.Models;
using System.Collections.Generic;

namespace E_Conc.Interface
{
    public interface IDataService
    {
        void InicializaDB();
        List<Produto> GetProdutos();
    }
}