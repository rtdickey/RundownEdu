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
    public class SegmentController : Controller
    {
        private readonly RundownEduDBContext _context;

        public SegmentController(RundownEduDBContext context)
        {
            _context = context;
        }

        // GET: Segment
        public ActionResult Index()
        {
            var rundownEduDBContext = _context.Segments.Include(s => s.Story);
            return View(rundownEduDBContext.ToList());
        }

        // GET: Segment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = _context.Segments.Include(s => s.Story).FirstOrDefault(m => m.SegmentId == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // GET: Segment/Create
        public ActionResult Create()
        {
            ViewData["StoryId"] = new SelectList(_context.Stories, "StoryId", "StoryId");
            return View();
        }

        // POST: Segment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("SegmentId,Type,Reader,EstimatedReadTime,ActualReadTime,StoryId")] Segment segment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(segment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StoryId"] = new SelectList(_context.Stories, "StoryId", "StoryId", segment.StoryId);
            return View(segment);
        }

        // GET: Segment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = _context.Segments.Find(id);
            if (segment == null)
            {
                return NotFound();
            }
            ViewData["StoryId"] = new SelectList(_context.Stories, "StoryId", "StoryId", segment.StoryId);
            return View(segment);
        }

        // POST: Segment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("SegmentId,Type,Reader,EstimatedReadTime,ActualReadTime,StoryId")] Segment segment)
        {
            if (id != segment.SegmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(segment);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegmentExists(segment.SegmentId))
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
            ViewData["StoryId"] = new SelectList(_context.Stories, "StoryId", "StoryId", segment.StoryId);
            return View(segment);
        }

        // GET: Segment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = _context.Segments
                .Include(s => s.Story)
                .FirstOrDefault(m => m.SegmentId == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // POST: Segment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var segment = _context.Segments.Find(id);
            _context.Segments.Remove(segment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SegmentExists(int id)
        {
            return _context.Segments.Any(e => e.SegmentId == id);
        }
    }
}
