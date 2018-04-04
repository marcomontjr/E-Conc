using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public IList<Produto> Produtos { get; set; }

        public CategoriaViewModel(IList<Produto> produtos)
        {
            Produtos = produtos;
        }        
    }
}