using E_Conc.Enum;

namespace E_Conc.Models
{
    public class Aluno : Usuario
    {
        public int Ra { get; private set; }
        public Curso Curso { get; set; }
        public TipoUsuario tipoUsuario = TipoUsuario.Aluno;
        public TipoUsuario TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }
        }

        public Aluno(int ra, Curso curso)
        {
            Ra = ra;
            Curso = curso;
        }
    }
}
