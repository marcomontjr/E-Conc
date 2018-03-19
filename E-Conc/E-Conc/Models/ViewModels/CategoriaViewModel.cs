using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CategoriaViewModel
    {
        public string Titulo { get; set; }
        public IList<Produto> Produtos { get; set; }

        public CategoriaViewModel(string titulo, IList<Produto> produtos)
        {
            Titulo = titulo;
            Produtos = produtos;
        }
    }
}