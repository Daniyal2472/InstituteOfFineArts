using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InstituteOfFineArts.Data;
using InstituteOfFineArts.Models;

namespace InstituteOfFineArts.Controllers
{
    public class PaintingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaintingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Painting
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Painting.Include(p => p.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Painting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = await _context.Painting
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painting == null)
            {
                return NotFound();
            }

            return View(painting);
        }

        // GET: Painting/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email");
            return View();
        }

        // POST: Painting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,ImageUrl,StudentId")] Painting painting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(painting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", painting.StudentId);
            return View(painting);
        }

        // GET: Painting/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = await _context.Painting.FindAsync(id);
            if (painting == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", painting.StudentId);
            return View(painting);
        }

        // POST: Painting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,ImageUrl,StudentId")] Painting painting)
        {
            if (id != painting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(painting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaintingExists(painting.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", painting.StudentId);
            return View(painting);
        }

        // GET: Painting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var painting = await _context.Painting
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (painting == null)
            {
                return NotFound();
            }

            return View(painting);
        }

        // POST: Painting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var painting = await _context.Painting.FindAsync(id);
            if (painting != null)
            {
                _context.Painting.Remove(painting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaintingExists(int id)
        {
            return _context.Painting.Any(e => e.Id == id);
        }
    }
}
