using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministracaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}