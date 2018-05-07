using E_Conc.Enum;
using System.ComponentModel.DataAnnotations;

namespace E_Conc.Models.ViewModels
{
    public class RegistroContaViewModel
    {
        [Required]
        public string Ra { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password does not match the confirmation password.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public string Instituicao { get; set; }
        [Required]
        public string InstituicaoSigla { get; set; }
        public string Telefone { get; set; }
        [Required]
        public TipoUsuario TipoUsuario { get; set; }
    }
}