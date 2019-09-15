using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RundownEdu.Models;

namespace RundownEdu.Controllers
{
    public class StoryController : Controller
    {
        private readonly RundownEduDBContext _context;

        public StoryController(RundownEduDBContext context)
        {
            _context = context;
        }

        // GET: Story
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stories.ToListAsync());
        }

        // GET: Story/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Stories
                .FirstOrDefaultAsync(m => m.StoryId == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // GET: Story/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Story/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoryId,Title")] Story story)
        {
            if (ModelState.IsValid)
            {
                _context.Add(story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET: Story/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Stories.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        // POST: Story/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoryId,Title")] Story story)
        {
            if (id != story.StoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryExists(story.StoryId))
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
            return View(story);
        }

        // GET: Story/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Stories
                .FirstOrDefaultAsync(m => m.StoryId == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Story/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var story = await _context.Stories.FindAsync(id);
            _context.Stories.Remove(story);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.StoryId == id);
        }
    }
}
