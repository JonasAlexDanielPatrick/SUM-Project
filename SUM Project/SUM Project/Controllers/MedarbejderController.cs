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
    public class MedarbejderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedarbejderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medarbejder
        public async Task<IActionResult> Index()
        {
            return View(await _context.MedarbejderModel.ToListAsync());
        }

        // GET: Medarbejder/Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.MedarbejderModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }

            return View(medarbejderModel);
        }

        // GET: Medarbejder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medarbejder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Navn,Tlf,Email,TimePris")] MedarbejderModel medarbejderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medarbejderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medarbejderModel);
        }

        // GET: Medarbejder/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.MedarbejderModel.SingleOrDefaultAsync(m => m.Id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }
            return View(medarbejderModel);
        }

        // POST: Medarbejder/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Navn,Tlf,Email,TimePris")] MedarbejderModel medarbejderModel)
        {
            if (id != medarbejderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medarbejderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedarbejderModelExists(medarbejderModel.Id))
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
            return View(medarbejderModel);
        }

        // GET: Medarbejder/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.MedarbejderModel
                .SingleOrDefaultAsync(m => m.Id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }

            return View(medarbejderModel);
        }

        // POST: Medarbejder/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medarbejderModel = await _context.MedarbejderModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.MedarbejderModel.Remove(medarbejderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedarbejderModelExists(int id)
        {
            return _context.MedarbejderModel.Any(e => e.Id == id);
        }
    }
}
