using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public IList<CategoriaViewModel> CategoriasViewModel { get; set; } = new List<CategoriaViewModel>();

        public CarrosselViewModel(IList<CategoriaViewModel> categoriasViewModel)
        {
            CategoriasViewModel = categoriasViewModel;
        }
    }
}