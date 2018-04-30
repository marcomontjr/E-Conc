using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class LoginController : Controller
    {  
        public IActionResult Login(LoginViewModel login)
        {
            return View();
        }        
    }
}