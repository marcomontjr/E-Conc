using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class IniciacaoCientificaViewModel
    {
        public List<Produto> Produtos { get; private set; }
        public Categoria Categoria { get; private set; }

        public IniciacaoCientificaViewModel(List<Produto> produtos)
        {
            Produtos = produtos;
            Categoria = Categoria.IniciacaoCientifica;
        }
    }
}
