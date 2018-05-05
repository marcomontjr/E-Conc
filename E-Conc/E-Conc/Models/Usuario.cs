using E_Conc.Enum;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Models
{
    public class Usuario : IdentityUser
    {
        public string Ra { get; private set; }
        public string Senha { get; private set; }   
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; private set; }
        public string InstituicaoSigla { get; private set; }
        public TipoUsuario TipoUsuario { get; private set; }
    }
}