using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;

        public ContaController(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager,
            IUsuarioRepository usuarioRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioRepo = usuarioRepo;
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
                    await _signInManager.SignInAsync(novoUsuario, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            }
            return View(registro);
        }
    }
}