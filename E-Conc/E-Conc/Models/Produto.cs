namespace E_Conc.Models
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Arquivo { get; private set; }
        public string Categoria { get; private set; }

        public Produto(int id, string nome, string arquivo, string categoria)
        {
            Id = id;
            Nome = nome;
            Arquivo = arquivo;
            Categoria = categoria;
        }
    }
}