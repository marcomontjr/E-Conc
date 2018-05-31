using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace E_Conc.Models.ViewModels
{
    public class UsuarioEditarFuncoesViewModel
    {
        public string Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public List<UsuarioFuncaoViewModel> Funcoes { get; set; }

        public UsuarioEditarFuncoesViewModel() { }

        public UsuarioEditarFuncoesViewModel(Usuario usuario, RoleManager<IdentityRole> roleManager, 
            UserManager<Usuario> userManager)
        {
            Id = usuario.Id;
            NomeCompleto = usuario.NomeCompleto;
            Email = usuario.Email;
            UserName = usuario.UserName;

            Funcoes = 
                roleManager
                .Roles
                .ToList()
                .Select(funcao => 
                    new UsuarioFuncaoViewModel
                    {
                        Nome = funcao.Name,
                        Id = funcao.Id,
                    })
                .ToList();
            
            var funcoesUsuario = userManager.GetRolesAsync(usuario).Result;

            foreach (var funcao in Funcoes)
            {
                foreach (var funcaoUsuario in funcoesUsuario)
                {
                    if (funcao.Nome == funcaoUsuario)                    
                        funcao.Selecionado = true;                    
                }               
            }                                          
        }
    }
}