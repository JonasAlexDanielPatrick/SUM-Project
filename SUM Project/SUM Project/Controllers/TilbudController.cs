using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SUM_Project.Data;
using SUM_Project.Models;
using SUM_Project.ViewModels;

namespace SUM_Project.Controllers
{
    public class TilbudController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TilbudController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tilbud
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tilbud.ToListAsync());
        }

        // GET: Tilbud/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tilbudModel = await _context.Tilbud
                .SingleOrDefaultAsync(m => m.tilbud_id == id);
            if (tilbudModel == null)
            {
                return NotFound();
            }

            // Find alle håndværkstimer med samme tilbuds ID
            List<HåndværkstimerViewModel> håndværkstimerVM = new List<HåndværkstimerViewModel>();
            foreach (var item in _context.TilbudHåndværkstimer.ToList())
            {
                if(item.tilbud_id == id)
                {
                    var håndværker = new HåndværkstimerViewModel
                    {
                        håndværkstimer = new HåndværkstimerModel
                        {
                            tilbud_id = item.tilbud_id,
                            med_id = item.med_id,
                            antal = item.antal,
                            brugt = item.brugt,
                            rabat = item.rabat
                        }
                    };
                    foreach (var medarbejder in _context.Medarbejder)
                    {
                        if(medarbejder.med_id == item.med_id)
                        {
                            håndværker.navn = medarbejder.navn;

                        }
                    }
                    håndværkstimerVM.Add(håndværker);
                }
            }

            // Find alle materialer med samme tilbuds ID
            List<MaterialeforbrugViewModel> materialeforbrugVM = new List<MaterialeforbrugViewModel>();
            foreach (var item in _context.Materialeforbrug.ToList())
            {
                if (item.tilbud_id == id)
                {
                    var materiale = new MaterialeforbrugViewModel
                    {
                        forbrug = new MaterialeforbrugModel
                        {
                            tilbud_id = item.tilbud_id,
                            mat_id = item.mat_id,
                            antal = item.antal,
                            brugt = item.brugt,
                            rabat = item.rabat
                        }
                    };
                    foreach (var mat in _context.Materialer)
                    {
                        if (mat.mat_id == item.mat_id)
                        {
                            materiale.navn = mat.navn;

                        }
                    }
                    materialeforbrugVM.Add(materiale);
                }
            }

            var vm = new TilbudDetailsViewModel
            {
                tilbud = tilbudModel,
                håndværkstimervm = håndværkstimerVM,
                forbrugvm = materialeforbrugVM
            };

            return View(vm);
        }

        // GET: Tilbud/Timer/5/2
        [Authorize]
        public async Task<IActionResult> Timer(int id1, int id2)
        {
            var håndværkstimerModel = await _context.TilbudHåndværkstimer.SingleOrDefaultAsync(m => m.tilbud_id == id1 && m.med_id == id2);
            if (håndværkstimerModel == null)
            {
                return NotFound();
            }

            return View(håndværkstimerModel);
        }

        // GET: Tilbud/Materialer/5/2
        [Authorize]
        public async Task<IActionResult> Materialer(int id1, int id2)
        {
            var materialeforbrugModel = await _context.Materialeforbrug.SingleOrDefaultAsync(m => m.tilbud_id == id1 && m.mat_id == id2);
            if (materialeforbrugModel == null)
            {
                return NotFound();
            }

            return View(materialeforbrugModel);
        }


        // POST: Tilbud/Timer/5/2
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Timer(int id1, int id2, [Bind("tilbud_id,med_id,antal,brugt,rabat")] HåndværkstimerModel håndværkstimerModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(håndværkstimerModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HåndværkstimerModelExists(håndværkstimerModel.tilbud_id))
                    {
                        Debug.WriteLine("NOT FOUND!" + håndværkstimerModel.tilbud_id);
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = håndværkstimerModel.tilbud_id });
            }
            Debug.WriteLine("ERROR!" + håndværkstimerModel.med_id);
            return View(håndværkstimerModel);
        }

        // POST: Tilbud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Materialer(int id1, int id2, [Bind("tilbud_id,mat_id,antal,brugt,rabat")] MaterialeforbrugModel materialeforbrugModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialeforbrugModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialeforbrugModelExists(materialeforbrugModel.tilbud_id))
                    {
                        Debug.WriteLine("NOT FOUND!" + materialeforbrugModel.tilbud_id);
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = materialeforbrugModel.tilbud_id });
            }
            Debug.WriteLine("ERROR!" + materialeforbrugModel.mat_id);
            return View(materialeforbrugModel);
        }


        private bool HåndværkstimerModelExists(int id)
        {
            return _context.TilbudHåndværkstimer.Any(e => e.tilbud_id == id);
        }

        private bool MaterialeforbrugModelExists(int id)
        {
            return _context.Materialeforbrug.Any(e => e.tilbud_id == id);
        }

        private bool TilbudModelExists(int id)
        {
            return _context.Tilbud.Any(e => e.tilbud_id == id);
        }
    }
}
