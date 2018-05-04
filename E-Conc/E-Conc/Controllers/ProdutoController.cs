using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detalhes()
        {
            return View();
        }
    }
}