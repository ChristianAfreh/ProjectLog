using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectLog.Models;
using ProjectLog.Services;
using System;
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
            try
            {
                var result = _sdgService.GetTotalNumberOfProjectUnderSdg();

                return View(result);
            }
            catch (Exception Ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = Ex.Message
                };

                return View("Error", errorViewModel);
            }
           
        }

    
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
