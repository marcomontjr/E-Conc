using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class EmpreendedorismoViewModel
    {
        public List<Produto> Produtos { get; private set; }
        public Categoria Categoria { get; private set; }

        public EmpreendedorismoViewModel(List<Produto> produtos)
        {
            Produtos = produtos;
            Categoria = Categoria.Empreendedorismo;
        }
    }
}
