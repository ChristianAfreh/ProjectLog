using Microsoft.AspNetCore.Mvc;
using ProjectLog.Models;
using ProjectLog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLog.Controllers
{
    public class DetailController : Controller
    {
        private readonly ISdgService _sdgService;

        public DetailController(ISdgService sdgService)
        {
            _sdgService = sdgService;
        }
        public IActionResult Index(int id)
        {
            try
            {
                ViewBag.id = id;
                var result = _sdgService.GetProjectUnderSDG(id);
                return View(result);

            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel()
                {
                    RequestId = ex.Message
                };

                return View("Error", errorViewModel);
            }
             
          
        }
    }
}
