namespace E_Conc.Models
{
    public class Curso
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Sigla { get; private set; }

        public Curso(int id, string nome, string sigla)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
        }
    }
}