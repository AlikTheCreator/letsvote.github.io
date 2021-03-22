using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VoteSystemWeb.Models;

namespace VoteSystemWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            var loginDTO = new LoginModelDTO();
            return View(loginDTO);
        }
        [HttpPost]
        public IActionResult Login(LoginModelDTO loginModel)
        {
            return RedirectToAction("Index", "Home");
        }


    }
}
