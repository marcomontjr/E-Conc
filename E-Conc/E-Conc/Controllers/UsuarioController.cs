using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace E_Conc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private UserManager<Usuario> _userManager;
        public UsuarioController(UserManager<Usuario> userManager) => _userManager = userManager;

        public IActionResult Index()
        {
            var usuarios =
                _userManager
                .Users
                .ToList()
                .Select(usuario => new UsuarioViewModel(usuario));

            return View(usuarios);
        }

        public IActionResult EditarFuncoes(string id)
        {
            return View();
        }
    }
}