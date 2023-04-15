using Kino.Data;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Kino.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            var seanse = context.Seanse.Include(x => x.Film).Include(x => x.Sala).ToList();
            return View(seanse);
        }

        public IActionResult SeansDetails(int id)
        {
            ViewBag.Seans = context.Seanse.Include(x => x.Film).Include(x => x.Sala).FirstOrDefault(x => x.IdSeans == id);
            return View(new ZamowienieViewModel());
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