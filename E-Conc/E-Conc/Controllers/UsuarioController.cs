using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private UserManager<Usuario> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UsuarioController(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var usuarios =
                _userManager
                .Users
                .ToList()
                .Select(usuario => new UsuarioViewModel(usuario));

            return View(usuarios);
        }

        public async Task<IActionResult> EditarFuncoes(string id)
        {
            var usuario = await  _userManager.FindByIdAsync(id);
            var modelo = new UsuarioEditarFuncoesViewModel(usuario, _roleManager, _userManager);

            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> EditarFuncoes(UsuarioEditarFuncoesViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(modelo.Id);
                var rolesUsuario = await _userManager.GetRolesAsync(usuario);

                var resultadoRemocao = await _userManager.RemoveFromRolesAsync(
                    usuario,
                    rolesUsuario.ToArray()
                );

                if (resultadoRemocao.Succeeded)
                {
                    var funcoesSelecionadas =
                        modelo
                            .Funcoes
                            .Where(funcao => funcao.Selecionado)
                            .Select(funcao => funcao.Nome)
                            .ToArray();

                    foreach (var funcao in funcoesSelecionadas)
                    {
                        var resultadoAdicao = await _userManager.AddToRoleAsync(
                                                usuario,
                                                funcao
                                                );
                    }  
                    
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}