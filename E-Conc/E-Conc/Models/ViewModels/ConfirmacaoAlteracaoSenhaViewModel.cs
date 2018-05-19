namespace E_Conc.Models.ViewModels
{
    public class ConfirmacaoAlteracaoSenhaViewModel
    {
        public string UsuarioId { get; set; }
        public string Token { get; set; }
        public string NovaSenha { get; set; }

        public ConfirmacaoAlteracaoSenhaViewModel()
        {

        }

        public ConfirmacaoAlteracaoSenhaViewModel(string usuarioId, string token, string novaSenha) 
            : this(usuarioId, token)
        {
            NovaSenha = novaSenha;
        }

        public ConfirmacaoAlteracaoSenhaViewModel(string usuario, string token)
        {
            UsuarioId = usuario;
            Token = token;
        }
    }
}