using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TN_Treasury_Web_Portal.Data;
using TN_Treasury_Web_Portal.Models;

namespace TN_Treasury_Web_Portal.Controllers
{
    public class GuideSectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuideSectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GuideSections
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GuideSection.Include(g => g.Guide);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GuideSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GuideSection == null)
            {
                return NotFound();
            }

            var guideSection = await _context.GuideSection
                .Include(g => g.Guide)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideSection == null)
            {
                return NotFound();
            }

            return View(guideSection);
        }

        // GET: GuideSections/Create
        public IActionResult Create()
        {
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id");
            return View();
        }

        // POST: GuideSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,GuideId")] GuideSection guideSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guideSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", guideSection.GuideId);
            return View(guideSection);
        }

        // GET: GuideSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GuideSection == null)
            {
                return NotFound();
            }

            var guideSection = await _context.GuideSection.FindAsync(id);
            if (guideSection == null)
            {
                return NotFound();
            }
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", guideSection.GuideId);
            return View(guideSection);
        }

        // POST: GuideSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,GuideId")] GuideSection guideSection)
        {
            if (id != guideSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guideSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuideSectionExists(guideSection.Id))
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
            ViewData["GuideId"] = new SelectList(_context.Guide, "Id", "Id", guideSection.GuideId);
            return View(guideSection);
        }

        // GET: GuideSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GuideSection == null)
            {
                return NotFound();
            }

            var guideSection = await _context.GuideSection
                .Include(g => g.Guide)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guideSection == null)
            {
                return NotFound();
            }

            return View(guideSection);
        }

        // POST: GuideSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GuideSection == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GuideSection'  is null.");
            }
            var guideSection = await _context.GuideSection.FindAsync(id);
            if (guideSection != null)
            {
                _context.GuideSection.Remove(guideSection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuideSectionExists(int id)
        {
          return (_context.GuideSection?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
