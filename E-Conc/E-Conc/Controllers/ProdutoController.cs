using E_Conc.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;

        [Authorize]
        public IActionResult Detalhes(int? produtoId)
        {
            if (produtoId != null)
                return View(_produtoRepo.GetProdutoById(produtoId));

            return RedirectToAction("Pedido", "Carrossel");
        }

        [Authorize]
        public IActionResult VerTudo()
        {
            return View();
        }

        [Authorize]
        public IActionResult Comprados()
        {
            return View();
        }

        [Authorize]
        public IActionResult PorCategoria()
        {
            return View();
        }

        [Authorize]
        public IActionResult PorOrientador()
        {
            return View();
        }
    }
}