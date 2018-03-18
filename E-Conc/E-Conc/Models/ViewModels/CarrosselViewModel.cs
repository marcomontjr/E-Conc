namespace E_Conc.Models.ViewModels
{
    public class CarrosselViewModel
    {
        public DesenvolvimentoViewModel DesenvolvimentoViewModel { get; set; }
        public EmpreendedorismoViewModel EmpreendedorismoViewModel { get; set; }
        public IniciacaoCientificaViewModel IniciacaoCientificaViewModel { get; set; }
        public PesquisaAcademicaViewModel PesquisaAcademicaViewModel { get; set; }

        public CarrosselViewModel(DesenvolvimentoViewModel desenvolvimentoViewModel, 
                                  EmpreendedorismoViewModel empreendedorismoViewModel, 
                                  IniciacaoCientificaViewModel iniciacaoCientificaViewModel, 
                                  PesquisaAcademicaViewModel pesquisaAcademicaViewModel)
        {
            DesenvolvimentoViewModel = desenvolvimentoViewModel;
            EmpreendedorismoViewModel = empreendedorismoViewModel;
            IniciacaoCientificaViewModel = iniciacaoCientificaViewModel;
            PesquisaAcademicaViewModel = pesquisaAcademicaViewModel;
        }
    }
}
