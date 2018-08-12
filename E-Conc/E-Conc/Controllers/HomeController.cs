using E_Conc.Models.ViewModels;
using E_Conc.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace E_Conc.Controllers
{
    public class HomeController : Controller
    {
        #region Propriedades
        private readonly IEmailService _emailService;
        #endregion

        #region Construtor
        public HomeController(IEmailService emailService) => _emailService = emailService;
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            ViewData["Message"] = "E-Conc";

            return View();
        }        

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contato(ContatoViewModel userData)
        {
            if (ModelState.IsValid)
                await _emailService.SendEmailHelpDesk(userData);
            else
                Error();

            return RedirectToAction("ContatoSucesso", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ContatoSucesso()
        {
            return View();
        }
    }
}