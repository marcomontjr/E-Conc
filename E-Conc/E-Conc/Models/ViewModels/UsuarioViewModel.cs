using System.ComponentModel;

namespace E_Conc.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        [DisplayName("Nome de Usuário")]
        public string UserName { get; set; }
        
        public UsuarioViewModel() { }

        public UsuarioViewModel(Usuario usuario)
        {
            Id = usuario.Id;
            NomeCompleto = usuario.NomeCompleto;
            Email = usuario.Email;
            UserName = usuario.UserName;
        }
    }
}