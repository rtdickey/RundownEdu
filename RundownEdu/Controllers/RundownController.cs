using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RundownEdu.Models;
using RundownEdu.ViewModels;

namespace RundownEdu.Controllers
{
    public class RundownController : BaseController
    {
        private readonly RundownEduDBContext db;

        public RundownController(RundownEduDBContext context)
        {
            db = context;
        }

        // GET: Rundown
        public ActionResult Index()
        {
            var vm = new List<ShowOverviewViewModel>();
            var showList = db.Shows.Where(x => x.Active).Include(x => x.Rundowns).OrderBy(x => x.Title).ToList();
            if (showList != null && showList.Count > 0)
            {
                showList.ForEach(x => vm.Add(new ShowOverviewViewModel(db, x)));
            }
            return View(vm);
        }

        // GET: Rundown/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = db.Rundowns.Include(r => r.Show).FirstOrDefault(m => m.Id == id);
            if (rundown == null)
            {
                return NotFound();
            }

            var rundownVM = new RundownViewModel(db, rundown);
            return View(rundownVM);
        }

        // GET: Rundown/Create
        public ActionResult Create()
        {
            ViewData["Show"] = new SelectList(db.Shows, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,StartTime,EndTime,ShowId,Active")] Rundown rundown)
        {
            if (ModelState.IsValid)
            {
                db.Add(rundown);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Show"] = new SelectList(db.Shows, "Id", "Title", rundown.ShowId);
            return View(rundown);
        }

        // GET: Rundown/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = db.Rundowns.Where(r => r.Id == id).Include(r => r.Show).Include(r => r.Stories).FirstOrDefault();
            if (rundown == null)
            {
                return NotFound();
            }
            var rundownVM = new RundownViewModel(db, rundown);
            ViewData["Show"] = new SelectList(db.Shows, "Id", "Title", rundownVM.ShowId);
            
            return View(rundownVM);
        }

        // POST: Rundown/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Title,StartTime,EndTime,ShowId,Active")] Rundown rundown)
        {
            if (id != rundown.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(rundown);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RundownExists(rundown.Id))
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
            ViewData["Show"] = new SelectList(db.Shows, "Id", "Title", rundown.ShowId);
            return View(rundown);
        }

        // GET: Rundown/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rundown = db.Rundowns.Include(r => r.Show).FirstOrDefault(m => m.Id == id);
            if (rundown == null)
            {
                return NotFound();
            }

            return View(rundown);
        }

        // POST: Rundown/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var rundown = db.Rundowns.Find(id);
            db.Rundowns.Remove(rundown);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool RundownExists(int id)
        {
            return db.Rundowns.Any(e => e.Id == id);
        }
    }
}
