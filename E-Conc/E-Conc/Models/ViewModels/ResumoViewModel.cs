namespace E_Conc.Models.ViewModels
{
    public class ResumoViewModel
    {
        public ItemPedido ItemPedido { get; private set; }
        public Aluno Aluno { get; private set; }

        public ResumoViewModel(ItemPedido itemPedido, Aluno aluno)
        {
            ItemPedido = itemPedido;
            Aluno = aluno;
        }
    }
}
