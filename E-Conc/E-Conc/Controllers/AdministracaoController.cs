using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdministracaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}