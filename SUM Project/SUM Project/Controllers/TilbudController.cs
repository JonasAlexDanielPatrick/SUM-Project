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

        // Test
        public IActionResult Tilbud()
        {
            Models.TilbudModel tilbud = new Models.TilbudModel { TilbudID = 1, KundeID = 1, Beskrivelse = "Test", Håndværkstimer = null, Kørsel = null, Materialer = null, Pris = 1000.00, ProjektAnsvarlig = 1, Rabat = 0, StartDato = "Idag", SlutDato = "Imorgen", Titel = "Projekt Alpha", Type = "Tilbud" };
            return View();
        }
    }
}