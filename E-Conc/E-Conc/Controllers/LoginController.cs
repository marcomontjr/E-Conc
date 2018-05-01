using E_Conc.Data.Interfaces;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public LoginController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        //TODO: Implementar Politicas de Segurança para acesso de usuários usando Microsoft.Identity.
        public IActionResult Login(LoginViewModel login)
        {
            var usuario = _usuarioRepo.GetUsuarioPorEmail(login);

            if (usuario != null)            
                return RedirectToAction("Carrossel", "Pedido");            

            return View();            
        }        
    }
}