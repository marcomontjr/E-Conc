namespace E_Conc.Models.ViewModels
{
    public class FinalizarProjetoViewModel
    {
        public Produto Produto { get; set; }
        public int? ProdutoId { get; set; }
        public string InformacoesProjeto { get; set; }
        public bool DeveSerDisponibilizado { get; set; }

        public FinalizarProjetoViewModel() { }

        public FinalizarProjetoViewModel(Produto produto, int? produtoId, 
            string informacoesProjeto, bool deveSerDisponibilizado)
        {
            Produto = produto;
            ProdutoId = produtoId;
            InformacoesProjeto = informacoesProjeto;
            DeveSerDisponibilizado = deveSerDisponibilizado;
        }
    }
}