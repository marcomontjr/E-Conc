using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEmailService _emailService;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private SignOutResult _signOutResult;

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
                    return View("AguardandoConfirmacao");
                }
                else
                    AdicionaErros(result);
            }
            return View(registro);
        }

        private async Task EnviaEmailConfirmacaoAsync(Usuario usuario)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            var linkDeCallback = Url.Action(
                                    "ConfirmaEmailAsync",
                                    "Conta",
                                    new { usuarioId = usuario.Id, token },
                                    Request.HttpContext.Request.Scheme);

            await _emailService.SendEmailAsync(usuario.Email, "E-Conc - Confirmação de Cadastro",
                       $"Bem-Vindo ao E-Conc, clique aqui {linkDeCallback} para confirmar seu email!");
        }

        public async Task<IActionResult> ConfirmaEmailAsync(string usuarioId, string token)
        {
            if (usuarioId == null || token == null)
                return View("Error");

            var usuario = _usuarioRepo.GetUsuarioById(usuarioId);

            var result = await _userManager.ConfirmEmailAsync(usuario, token);

            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            else
                return View("Error");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(modelo.Email);

                if (usuario == null)
                    SenhaOuUsuarioInvalidos();

                var signInResult = await _signInManager.PasswordSignInAsync(
                                    usuario, 
                                    modelo.Senha, 
                                    isPersistent: modelo.ContinuarLogado, 
                                    lockoutOnFailure: false);

                if (signInResult.Succeeded)
                    return RedirectToAction("Index", "Home");
                else
                    SenhaOuUsuarioInvalidos();
            }            
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult SenhaOuUsuarioInvalidos()
        {
            ModelState.AddModelError("", "Credenciais Inválidas");
            return View("Login");
        }

        private void AdicionaErros(IdentityResult result)
        {
            foreach (var error in result.Errors)            
                ModelState.AddModelError("", error.Description);
        }
    }
}