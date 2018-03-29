﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_Conc.Models;

namespace E_Conc.Controllers
{
    public class HomeController : Controller
    {
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
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}