using E_Conc.Enum;

namespace E_Conc.Models
{
    public class Aluno : Usuario
    {
        public string Ra { get; private set; }
        public Curso Curso { get; set; }
        public ItemPedido ItemPedido { get; private set; }
        public TipoUsuario tipoUsuario = TipoUsuario.Aluno;
        public TipoUsuario TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
        }

        public Aluno(string ra, Curso curso)
        {
            Ra = ra;
            Curso = curso;
        }
    }
}
