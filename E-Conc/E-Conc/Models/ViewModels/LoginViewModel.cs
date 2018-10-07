using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "E-Mail é Obrigatório")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha é Obrigatória")]
        public string Senha { get; set; }

        public bool ContinuarLogado { get; set; }
    }
}