using E_Conc.Enum;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Models.ViewModels
{
    public class RegistroContaViewModel : IdentityUser
    {
        public string Ra { get; set; }
        public string Senha { get; set; }
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Instituicao { get; set; }
        public string InstituicaoSigla { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}