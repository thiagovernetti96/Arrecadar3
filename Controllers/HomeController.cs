using Arrecadar3.Data;
using Arrecadar3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Arrecadar3.ViewModels;

namespace Arrecadar3.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly Arrecadar3Context _context;

        public HomeController(ILogger<HomeController> logger,Arrecadar3Context context)
        {
              _context = context;
           
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Campanhas = _context.Campanha.ToList(),
                Ongs = _context.Ong.ToList()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
