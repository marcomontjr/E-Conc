﻿using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    public class ContaController : Controller
    {
        #region Propriedades
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly IEmailService _emailService;
        private readonly ISmsService _smsService;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Construtor
        public ContaController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,
            IUsuarioRepository usuarioRepo, IEmailService emailService, ISmsService smsService,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioRepo = usuarioRepo;
            _emailService = emailService;
            _smsService = smsService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Acesso a Administradores, Orientadores e Alunos
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> VerificacaoDoisFatores(Usuario usuario)
        {
            var token =
                await _userManager.GenerateTwoFactorTokenAsync(usuario, "SMS");

            await _smsService.SendSmsAsync
                (usuario.PhoneNumber, $"Token de Confirmação: {token}");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> VerificacaoDoisFatores(ContaVerificacaoDoisFatoresViewModel modelo)
        {
            var resultado =
                await _signInManager.TwoFactorSignInAsync(
                        "SMS",
                        modelo.Token,
                        isPersistent: modelo.ContinuarLogado,
                        rememberClient: modelo.LembrarDesteComputador);

            if (resultado.Succeeded)
                return RedirectToAction("Index", "Home");

            return View("Error");
        }

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult ConfirmaAlteracaoSenha(string usuarioId, string token)
        {
            var modelo = new ConfirmacaoAlteracaoSenhaViewModel(usuarioId, token);
            return View(modelo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> ConfirmaAlteracaoSenha(ConfirmacaoAlteracaoSenhaViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuarioRepo.GetById(Convert.ToInt32(modelo.UsuarioId));
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

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> Logoff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult EsquecerNavegador()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                if (!cookie.Equals("ContinuarLogado"))
                    Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("MinhaConta");
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> DeslogarDeTodosOsLocais()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                 ClaimTypes.NameIdentifier).Value;

            var usuario = await _userManager.FindByIdAsync(userId);

            await _userManager.UpdateSecurityStampAsync(usuario);

            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> MinhaConta()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                ClaimTypes.NameIdentifier).Value;

            var usuario = await _userManager.FindByIdAsync(userId);

            var modelo = new ContaMinhaContaViewModel(
                    usuario.NomeCompleto,
                    usuario.PhoneNumber,
                    usuario.TwoFactorEnabled,
                    usuario.PhoneNumberConfirmed
                );

            return View(modelo);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> MinhaConta(ContaMinhaContaViewModel modelo)
        {
            //System.Text.RegularExpressions.Match Match =
            //        System.Text.RegularExpressions.Regex
            //        .Match(modelo.NumeroDeCelular, @"^[1-9][1-9]{2}(?:[2-8]|[1-9])[0-9]{3}[0-9]{4}$");

            //if (!Match.Success)
            //{
            //    ModelState.AddModelError("", "Este Número de Telefone não é Válido");
            //    return View("MinhaConta", modelo);
            //}

            if (ModelState.IsValid)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(
                ClaimTypes.NameIdentifier).Value;

                var usuario = await _userManager.FindByIdAsync(userId);

                usuario.NomeCompleto = modelo.NomeCompleto;
                usuario.PhoneNumber = modelo.NumeroDeCelular;

                //if (!usuario.PhoneNumberConfirmed)
                //    await EnviarSmsConfirmacaoAsync(usuario);
                //else
                usuario.PhoneNumberConfirmed = true;
                usuario.TwoFactorEnabled = modelo.HabilitarAutenticacaoDeDoisFatores;

                var resultadoUpdate = await _userManager.UpdateAsync(usuario);

                if (resultadoUpdate.Succeeded)
                    return View("MinhaContaSucesso");

                AdicionaErros(resultadoUpdate);
            }
            return View();
        }

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task EnviarSmsConfirmacaoAsync(Usuario usuario)
        {
            var token =
                await _userManager.GenerateChangePhoneNumberTokenAsync(
                    usuario, usuario.PhoneNumber);

            await _smsService.SendSmsAsync
                (usuario.PhoneNumber, $"Token de Confirmação: {token}");
        }

        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public IActionResult VerificacaoCodigoCelular()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Orientador, Aluno")]
        public async Task<IActionResult> VerificacaoCodigoCelular(string token)
        {
            var usuario = await GetCurrentUserAsync();

            var resultado =
                await _userManager.ChangePhoneNumberAsync(
                    usuario,
                    usuario.PhoneNumber,
                    token);

            if (resultado.Succeeded)
                return RedirectToAction("Index", "Home");

            AdicionaErros(resultado);

            return View();
        }
        #endregion

        #region Acesso a Administradores
        [Authorize(Roles = "Admin")]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Registrar(RegistroContaViewModel registro)
        {
            if (ModelState.IsValid)
            {
                var novoUsuario = new Usuario(registro);
                var result = await _userManager.CreateAsync(novoUsuario, registro.Senha);

                if (result.Succeeded)
                {
                    await EnviaEmailConfirmacaoAsync(novoUsuario);
                    UsuarioEditarFuncoesViewModel EditFuncoes = new UsuarioEditarFuncoesViewModel()
                    {
                        Id = novoUsuario.Id,
                        Email = novoUsuario.Email,
                        NomeCompleto = novoUsuario.NomeCompleto,
                        UserName = novoUsuario.Email
                    };

                    return RedirectToAction("EditarFuncoes", "Usuario", EditFuncoes);
                }
                else
                    AdicionaErros(result);
            }
            return View(registro);
        }

        [Authorize(Roles = "Admin")]
        private async Task EnviaEmailConfirmacaoAsync(Usuario usuario)
        {
            string token = await _userManager.GenerateEmailConfirmationTokenAsync(usuario);
            string linkDeCallback = Url.Action(
                                    "ConfirmaEmailAsync",
                                    "Conta",
                                    new { usuarioId = usuario.Id, token },
                                    Request.HttpContext.Request.Scheme);

            await _emailService.SendEmailAsync(usuario.Email, "E-Conc - Confirmação de Cadastro",
                       $"Bem-Vindo ao E-Conc, clique no link abaixo para confirmar seu email:" +
                       "\n\n" +
                       $" {linkDeCallback}");
        }
        #endregion

        #region Métodos Auxiliares
        public async Task<IActionResult> ConfirmaEmailAsync(string usuarioId, string token)
        {
            if (usuarioId == null || token == null)
                return View("Error");

            Usuario usuario = _usuarioRepo.GetUsuarioById(usuarioId);

            IdentityResult result = await _userManager.ConfirmEmailAsync(usuario, token);

            if (result.Succeeded)
                return RedirectToAction("Login");
            else
                return View("Error");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByEmailAsync(modelo.Email);

                if (usuario == null)
                {
                    ModelState.AddModelError("", "Senha ou Usuário Inválidos");
                    return View("Login");
                }                    

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
                    return RedirectToAction("Carrossel", "Produto");
                }

                if (signInResult.RequiresTwoFactor)
                    return RedirectToAction("VerificacaoDoisFatores", usuario);

                else if (signInResult.IsLockedOut)
                {
                    var senhaCorreta = await _userManager.CheckPasswordAsync(usuario, modelo.Senha);
                    if (senhaCorreta)
                        ModelState.AddModelError("", "A conta está bloqueada");
                    else
                        ModelState.AddModelError("", "Senha ou Usuário Inválidos");
                }
                else
                    ModelState.AddModelError("", "Senha ou Usuário Inválidos");
            }
            return View(modelo);
        }

        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        private Task<Usuario> GetCurrentUserAsync() => _userManager.GetUserAsync(User);

        private void AdicionaErros(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
        #endregion
    }
}