using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]        
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public bool ContinuarLogado { get; set; }
    }
}