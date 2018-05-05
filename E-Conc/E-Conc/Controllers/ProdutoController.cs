using E_Conc.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Conc.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepo;
        public IActionResult Detalhes(int? produtoId)
        {
            if (produtoId != null)                
                return View(_produtoRepo.GetProdutoById(produtoId));

            return RedirectToAction("");
        }
    }
}