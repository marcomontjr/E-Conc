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

        public IActionResult Login()
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
                                    lockoutOnFailure: true);

                if (signInResult.Succeeded)
                {
                    if (!usuario.EmailConfirmed)
                    {
                        await _signInManager.SignOutAsync();
                        return View("AguardandoConfirmacao");
                    }
                    return RedirectToAction("Index", "Home");
                }

                else if (signInResult.IsLockedOut)
                {
                    var senhaCorreta = await _userManager.CheckPasswordAsync(usuario, modelo.Senha);
                    if (senhaCorreta)
                        ModelState.AddModelError("", "A conta está bloqueada");
                    else
                        SenhaOuUsuarioInvalidos();
                }
                else
                    SenhaOuUsuarioInvalidos();
            }
            return View(modelo);
        }

        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EsqueciSenha(string email)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(email);

                if (usuario != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);

                    var linkDeCallback = Url.Action(
                                    "ConfirmaAlteracaoSenha",
                                    "Conta",
                                    new { usuarioId = usuario.Id, token },
                                    Request.HttpContext.Request.Scheme);

                    await _emailService.SendEmailAsync(usuario.Email, "E-Conc - Alteração de Senha",
                               $"Clique aqui {linkDeCallback} para alterar sua senha!");
                }
                return View("EmailAlteracaoSenhaEnviado");
            }
            return View();
        }

        public IActionResult ConfirmaAlteracaoSenha(string usuarioId, string token)
        {            
            var modelo = new ConfirmacaoAlteracaoSenhaViewModel(usuarioId, token);
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmaAlteracaoSenha(ConfirmacaoAlteracaoSenhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuarioRepo.GetUsuarioById(modelo.UsuarioId);
                var result = 
                    await _userManager.ResetPasswordAsync(
                    usuario, 
                    modelo.Token, 
                    modelo.NovaSenha);

                if (result.Succeeded)                
                    return RedirectToAction("Index", "Home");                

                AdicionaErros(result);
            }
            return View();
        }
        
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