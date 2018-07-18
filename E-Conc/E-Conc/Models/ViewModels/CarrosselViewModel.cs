using E_Conc.Enum;

namespace E_Conc.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public CategoriaViewModel[] CategoriasViewModel { get; set; }
        public Categoria Categoria { get; private set; }

        public CarrosselViewModel(CategoriaViewModel[] categoriasViewModel)
        {
            CategoriasViewModel = categoriasViewModel;
        }
    }
}