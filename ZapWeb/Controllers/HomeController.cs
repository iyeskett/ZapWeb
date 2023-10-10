using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZapWeb.Models;

namespace ZapWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Conversacao()
        {
            return View();
        }
    }
}