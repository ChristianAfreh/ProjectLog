using Microsoft.AspNetCore.Mvc;
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
            var result =_sdgService.GetProjectUnderSDG( id);
            return View(result);
        }
    }
}
