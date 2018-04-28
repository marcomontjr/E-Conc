using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class LoginController : Controller
    {  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string login, string senha)
        {
            return View();
        }        
    }
}