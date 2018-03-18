using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class DesenvolvimentoViewModel
    {
        public List<Produto> Produtos { get; private set; }
        public Categoria Categoria { get; private set; }

        public DesenvolvimentoViewModel(List<Produto> produtos)
        {
            Produtos = produtos;
            Categoria = Categoria.Desenvolvimento;
        }
    }
}