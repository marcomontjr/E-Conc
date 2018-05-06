using E_Conc.Data.Interfaces;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public ContaController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(RegistroContaViewModel registro)
        {
            var novoUsuario = new Usuario(registro);
            var criarUsuario = _usuarioRepo.RegistrarNovoUsuario(novoUsuario);

            if (criarUsuario != null)
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home");
        }
    }
}