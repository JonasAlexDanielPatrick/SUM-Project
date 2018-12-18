using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SUM_Project.Data;
using SUM_Project.Models;

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tilbud.ToListAsync());
        }

        // GET: Tilbud/Details/5
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

            return View(tilbudModel);
        }

        // GET: Tilbud/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tilbud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tilbud_id,kunde_id,titel,beskrivelse,type,start_dato,slut_dato,rabat,pris,projekt_ansvarlig")] TilbudModel tilbudModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tilbudModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tilbudModel);
        }

        // GET: Tilbud/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tilbudModel = await _context.Tilbud.SingleOrDefaultAsync(m => m.tilbud_id == id);
            if (tilbudModel == null)
            {
                return NotFound();
            }
            return View(tilbudModel);
        }

        // POST: Tilbud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tilbud_id,kunde_id,titel,beskrivelse,type,start_dato,slut_dato,rabat,pris,projekt_ansvarlig")] TilbudModel tilbudModel)
        {
            if (id != tilbudModel.tilbud_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tilbudModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TilbudModelExists(tilbudModel.tilbud_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tilbudModel);
        }

        // GET: Tilbud/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(tilbudModel);
        }

        // POST: Tilbud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tilbudModel = await _context.Tilbud.SingleOrDefaultAsync(m => m.tilbud_id == id);
            _context.Tilbud.Remove(tilbudModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TilbudModelExists(int id)
        {
            return _context.Tilbud.Any(e => e.tilbud_id == id);
        }
    }
}
