using System.Collections.Generic;

namespace E_Conc.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public List<Produto> Produto { get; private set; }

        public CarrosselViewModel(List<Produto> produtos)
        {
            Produto = produtos;
        }
    }
}
