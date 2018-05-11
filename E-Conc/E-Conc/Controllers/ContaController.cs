using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEmailService _emailService;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public ContaController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,
            IUsuarioRepository usuarioRepo, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioRepo = usuarioRepo;
            _emailService = emailService;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroContaViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var novoUsuario = new Usuario(registro);
                var result = await _userManager.CreateAsync(novoUsuario, registro.Senha);

                if (result.Succeeded)
                {
                    await EnviaEmailConfirmacaoAsync(novoUsuario);
                    return RedirectToAction("Index", "Home");
                }
                else
                    AdicionaErros(result);
            }
            return View(registro);
        }

        private async Task EnviaEmailConfirmacaoAsync(Usuario usuario)
        {
            await _emailService.SendEmailAsync(usuario.Email, "Confirmação de Cadastro",
                       $"Parabéns, você se Cadastrou no E-Conc");         
        }

        private void AdicionaErros(IdentityResult result)
        {
            foreach (var error in result.Errors)            
                ModelState.AddModelError("", error.Description);
        }
    }
}