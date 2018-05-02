using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]        
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}