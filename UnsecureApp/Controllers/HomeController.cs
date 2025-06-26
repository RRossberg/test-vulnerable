using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UnsecureApp.Models;

namespace UnsecureApp.Controllers
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

        public IActionResult Privacy(string parameter = null)
        {
            ReadFile(parameter);
            RunCommand(parameter);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string ReadFile(string filename)
        {
            // potential Path Traversal
            return File.ReadAllText("uploads/" + filename);
        }

        private void RunCommand(string userInput)
        {
            // Command Injection
            Process.Start("cmd.exe", "/C " + userInput);
        }
    }
}
