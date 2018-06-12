using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models
{
    public class Usuario : IdentityUser
    {
        public string Ra { get; set; }
        [StringLength(50, MinimumLength = 5, 
            ErrorMessage = "Nome deve ter entre 5 e 50 caracteres")]
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