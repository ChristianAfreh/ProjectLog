using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            var result = _sdgService.GetTotalNumberOfProjectUnderSdg();

            return View(result);
        }

    
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
