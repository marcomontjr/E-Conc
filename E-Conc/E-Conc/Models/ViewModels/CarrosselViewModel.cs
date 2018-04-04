using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public CategoriaViewModel[] CategoriasViewModel { get; set; }

        public CarrosselViewModel(CategoriaViewModel[] categoriasViewModel)
        {
            CategoriasViewModel = categoriasViewModel;
        }       
    }
}