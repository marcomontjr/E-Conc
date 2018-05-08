using E_Conc.Enum;
using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models.ViewModels
{
    public class RegistroContaViewModel
    {
        public string Ra { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }    
        public string NomeCompleto { get; set; }
        public string Instituicao { get; set; }
        public string InstituicaoSigla { get; set; }
        public string Telefone { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}