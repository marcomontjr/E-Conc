namespace E_Conc.Models.ViewModels
{
    public class ResumoViewModel
    {
        public Produto Produto { get; private set; }
        public ItemPedido ItemPedido { get; private set; }
        public Aluno Aluno { get; private set; }
        public Curso Curso { get; private set; }

        public ResumoViewModel(Produto produto, ItemPedido itemPedido, Aluno aluno, Curso curso)
        {
            Produto = produto;
            ItemPedido = itemPedido;
            Aluno = aluno;
            Curso = curso;
        }
    }
}
