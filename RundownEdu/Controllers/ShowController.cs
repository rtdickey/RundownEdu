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
    public class ShowController : Controller
    {
        private readonly RundownEduDBContext _context;

        public ShowController(RundownEduDBContext context)
        {
            _context = context;
        }

        // GET: Show
        public ActionResult Index()
        {
            var modelList = _context.Shows.ToList();
            return View(modelList);
        }

        // GET: Show/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = _context.Shows.FirstOrDefault(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // GET: Show/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Active,Color")] Show show)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(show);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex)
                {
                    return View(show);
                }
            }
            return View(show);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = _context.Shows.Where(s => s.Id == id).FirstOrDefault();
            if (show == null)
            {
                return NotFound();
            }
            return View(show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,Active,Color")] Show show)
        {
            if (id != show.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(show);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShowExists(show.Id))
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
            return View(show);
        }

        // GET: Show/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var show = _context.Shows.FirstOrDefault(m => m.Id == id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: Show/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var show = _context.Shows.Find(id);
            _context.Shows.Remove(show);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
