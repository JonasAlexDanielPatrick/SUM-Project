using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SUM_Project.Controllers
{
    public class TilbudController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}