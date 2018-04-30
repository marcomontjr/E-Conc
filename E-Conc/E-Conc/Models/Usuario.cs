using E_Conc.Enum;

namespace E_Conc.Models
{
    public class Usuario : BaseModel
    {
        public string Ra { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }   
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
}
}