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
    public class MedarbejderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedarbejderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Medarbejder
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Medarbejder.ToListAsync());
        }

        // GET: Medarbejder/Details
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.Medarbejder
                .SingleOrDefaultAsync(m => m.med_id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }

            return View(medarbejderModel);
        }

        // GET: Medarbejder/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medarbejder/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("med_id,navn,tlf,email,timepris")] MedarbejderModel medarbejderModel)
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
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.Medarbejder.SingleOrDefaultAsync(m => m.med_id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }
            return View(medarbejderModel);
        }

        // POST: Medarbejder/Edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("med_id,navn,tlf,email,timepris")] MedarbejderModel medarbejderModel)
        {
            if (id != medarbejderModel.med_id)
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
                    if (!MedarbejderModelExists(medarbejderModel.med_id))
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
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medarbejderModel = await _context.Medarbejder
                .SingleOrDefaultAsync(m => m.med_id == id);
            if (medarbejderModel == null)
            {
                return NotFound();
            }

            return View(medarbejderModel);
        }

        // POST: Medarbejder/Delete
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medarbejderModel = await _context.Medarbejder.SingleOrDefaultAsync(m => m.med_id == id);
            _context.Medarbejder.Remove(medarbejderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedarbejderModelExists(int id)
        {
            return _context.Medarbejder.Any(e => e.med_id == id);
        }

        public FileStreamResult SaveData(string example)
        {            
            string output = JsonConvert.SerializeObject(_context.Medarbejder);

            List<MedarbejderModel> medarbejdere = JsonConvert.DeserializeObject<List<MedarbejderModel>>(output);
 
            MemoryStream stream = new MemoryStream();

            TextWriter tw = new StreamWriter(stream);

            foreach (var medarbejder in medarbejdere)
            {
                tw.WriteLine("{0} - {1} - {2} - {3} - {4}", medarbejder.navn, medarbejder.med_id, medarbejder.tlf, medarbejder.email, medarbejder.timepris);
            }

            tw.Flush();

            byte[] bytes = stream.ToArray();
            stream = new MemoryStream(bytes);

            return File(stream, "text/plain", String.Format("{0}.txt", example));
        }
    }
}
