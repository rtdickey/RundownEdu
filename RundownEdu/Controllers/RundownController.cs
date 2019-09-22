using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RundownEdu.Models;
using RundownEdu.ViewModels;

namespace RundownEdu.Controllers
{
    public class RundownController : Controller
    {
        private readonly RundownEduDBContext _context;

        public RundownController(RundownEduDBContext context)
        {
            _context = context;
        }

        // GET: Rundown
        public ActionResult Index()
        {
            var modelList = _context.Rundowns.Include(r => r.Show).ToList();
            return View(modelList);
        }

        // GET: Rundown/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = await _context.Rundowns
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.RundownId == id);
            if (rundown == null)
            {
                return NotFound();
            }

            var rundownVM = new RundownViewModel(_context, rundown);
            return View(rundownVM);
        }

        // GET: Rundown/Create
        public IActionResult Create()
        {
            ViewData["Show"] = new SelectList(_context.Shows, "ShowId", "Title");
            return View();
        }

        // POST: Rundown/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RundownId,Title,StartTime,EndTime,ShowId,Active")] Rundown rundown)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rundown);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Show"] = new SelectList(_context.Shows, "ShowId", "Title", rundown.ShowId);
            return View(rundown);
        }

        // GET: Rundown/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = await _context.Rundowns.FindAsync(id);
            if (rundown == null)
            {
                return NotFound();
            }
            var rundownVM = new RundownViewModel(_context, rundown);
            ViewData["Show"] = new SelectList(_context.Shows, "ShowId", "Title", rundownVM.ShowId);
            
            return View(rundownVM);
        }

        // POST: Rundown/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RundownId,Title,StartTime,EndTime,ShowId,Active")] Rundown rundown)
        {
            if (id != rundown.RundownId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rundown);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RundownExists(rundown.RundownId))
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
            ViewData["Show"] = new SelectList(_context.Shows, "ShowId", "Title", rundown.ShowId);
            return View(rundown);
        }

        // GET: Rundown/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = await _context.Rundowns
                .Include(r => r.Show)
                .FirstOrDefaultAsync(m => m.RundownId == id);
            if (rundown == null)
            {
                return NotFound();
            }

            return View(rundown);
        }

        // POST: Rundown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rundown = await _context.Rundowns.FindAsync(id);
            _context.Rundowns.Remove(rundown);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RundownExists(int id)
        {
            return _context.Rundowns.Any(e => e.RundownId == id);
        }
    }
}
