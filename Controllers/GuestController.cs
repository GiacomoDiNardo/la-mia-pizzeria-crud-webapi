using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_static.Controllers
{
    public class GuestController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["title"] = "Home";
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["title"] = "Dettaglio Post";
            return View(id);
        }

    }
}