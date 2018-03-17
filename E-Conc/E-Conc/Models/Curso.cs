namespace E_Conc.Models
{
    public class Curso
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }

        public Curso(string nome, string sigla)
        {
            Nome = nome;
            Sigla = sigla;
        }
    }
}