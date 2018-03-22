using E_Conc.Data;
using E_Conc.Interface;
using E_Conc.Models;
using E_Conc.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_Conc.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IDataService _dataService;
        public PedidoController(IDataService dataService)
        {
            _dataService = dataService;
        }
        public IActionResult Carrossel()
        {
            //List<Produto> produtos = _dataService.GetProdutos();
            return View();
        }

        public IActionResult Carrinho()
        {
            return View();
        }        

        public IActionResult Resumo()
        {
            return View();
        }
    }
}