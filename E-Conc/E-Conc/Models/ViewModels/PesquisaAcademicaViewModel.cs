using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class PesquisaAcademicaViewModel
    {
        public List<Produto> Produtos { get; private set; }
        public Categoria Categoria { get; private set; }

        public PesquisaAcademicaViewModel(List<Produto> produtos)
        {
            Produtos = produtos;
            Categoria = Categoria.PesquisaAcademica;
        }
    }
}
