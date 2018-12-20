using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SUM_Project.Data;
using SUM_Project.Models;


namespace SUM_Project.Controllers
{
    public class ForbrugController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForbrugController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Materialeforbrug.ToListAsync());
        }
    }
}
