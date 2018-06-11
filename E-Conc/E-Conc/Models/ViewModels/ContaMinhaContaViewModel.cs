namespace E_Conc.Models.ViewModels
{
    public class ContaMinhaContaViewModel
    {
        public string NomeCompleto { get; set; }
        public string NumeroDeCelular { get; set; }
        public bool HabilitarAutenticacaoDeDoisFatores { get; set; }
        public bool NumeroCelularConfirmado { get; set; }

        public ContaMinhaContaViewModel() { }

        public ContaMinhaContaViewModel(string nomeCompleto, string numeroDeCelular, 
            bool habilitarAutenticacaoDeDoisFatores, bool numeroCelularConfirmado)
        {
            NomeCompleto = nomeCompleto;
            NumeroDeCelular = numeroDeCelular;
            HabilitarAutenticacaoDeDoisFatores = habilitarAutenticacaoDeDoisFatores;
            NumeroCelularConfirmado = numeroCelularConfirmado;
        }
    }
}