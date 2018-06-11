using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace E_Conc.Models
{
    public class Usuario : IdentityUser
    {
        public string Ra { get; set; }
        public string NomeCompleto { get; set; }
        public string Instituicao { get; set; }
        public string InstituicaoSigla { get; set; }

        public Usuario() { }

        public Usuario(RegistroContaViewModel modelo)
        {
            Ra = modelo.Ra;
            PasswordHash = modelo.Senha;
            NomeCompleto = modelo.NomeCompleto;
            PhoneNumber = modelo.Telefone;
            Instituicao = modelo.Instituicao;
            InstituicaoSigla = modelo.InstituicaoSigla;
            UserName = modelo.Email;
            Email = modelo.Email;
        }
    }
}