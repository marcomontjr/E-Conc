namespace E_Conc.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginViewModel() { }

        public LoginViewModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}