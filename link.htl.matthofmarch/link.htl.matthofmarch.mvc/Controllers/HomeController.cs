using link.htl.matthofmarch.mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace link.htl.matthofmarch.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static readonly List<Guest> _guests = new List<Guest>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {
            return View(_guests);
        }

        [HttpGet] 
        public IActionResult SignUp()
        {
           return View();
        }

        [HttpPost]
        public IActionResult SignUp(Guest viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _guests.Add(viewModel??new Guest{Name= "Invalid Username" });

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
