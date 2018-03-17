namespace E_Conc.Models
{
    public class Orientador
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        public Orientador(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}