using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models;
using System.Diagnostics;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LabDBContext _context;

        public HomeController(ILogger<HomeController> logger, LabDBContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(b => b.Username == username);

            if (user != null)
            {
                if(user.Password == password)
                {
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    HttpContext.Session.SetString("FirstName", user.FirstName);
                    HttpContext.Session.SetString("LastName", user.LastName);
                    HttpContext.Session.SetString("Username", user.Username);

                    if (user.Property == "Client")
                    {
                        return RedirectToAction("Index", "Client");
                    }
                    else if (user.Property == "Seller")
                    {
                        return RedirectToAction("Index", "Seller");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            
            return View("LoginAgain");
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
