namespace E_Conc.Models
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }

        public Curso(int id, string nome, string sigla) : this(nome, sigla)
        {
            Id = id;            
        }

        public Curso(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}