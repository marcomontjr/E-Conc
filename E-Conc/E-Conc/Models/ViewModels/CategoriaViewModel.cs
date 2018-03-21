using E_Conc.Enum;
using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public Categoria Categoria { get; set; }
        public IList<Produto> Produtos { get; set; }

        public CategoriaViewModel(Categoria categoria, IList<Produto> produtos)
        {
            Categoria = categoria;
            Produtos = produtos;
        }        
    }
}