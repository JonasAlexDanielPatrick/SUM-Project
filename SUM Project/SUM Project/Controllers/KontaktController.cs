using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SUM_Project.Controllers
{
    public class KontaktController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}