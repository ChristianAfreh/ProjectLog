using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectLog.Models;
using ProjectLog.Services;
using System.Diagnostics;

namespace ProjectLog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISdgService _sdgService;
        public HomeController(ISdgService sdgService)
        {
            _sdgService = sdgService;
        }
        public IActionResult Index()
        {
           var result = _sdgService.GetAllSdgs();
            return View(result);
        }

        public IActionResult ProjectList()
        {

            return View();
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
