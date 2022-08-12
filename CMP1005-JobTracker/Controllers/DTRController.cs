using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMP1005_JobTracker.Models;

namespace CMP1005_JobTracker.Controllers
{
    public class DTRController : Controller
    {
        private readonly JobTrackerContext _context;

        public DTRController(JobTrackerContext context)
        {
            _context = context;
        }

        // GET: DTR
        public async Task<IActionResult> Index()
        {
            var jobTrackerContext = _context.DTR.Include(d => d.Jobs);
            return View(await jobTrackerContext.ToListAsync());
        }

        // GET: DTR/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTR = await _context.DTR
                .Include(d => d.Jobs)
                .FirstOrDefaultAsync(m => m.DTRId == id);
            if (dTR == null)
            {
                return NotFound();
            }

            return View(dTR);
        }

        // GET: DTR/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company");
            return View();
        }

        // POST: DTR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DTRId,TimeIn,TimeOut,JobId")] DTR dTR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dTR);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", dTR.JobId);
            return View(dTR);
        }

        // GET: DTR/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTR = await _context.DTR.FindAsync(id);
            if (dTR == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", dTR.JobId);
            return View(dTR);
        }

        // POST: DTR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DTRId,TimeIn,TimeOut,JobId")] DTR dTR)
        {
            if (id != dTR.DTRId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dTR);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DTRExists(dTR.DTRId))
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
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", dTR.JobId);
            return View(dTR);
        }

        // GET: DTR/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dTR = await _context.DTR
                .Include(d => d.Jobs)
                .FirstOrDefaultAsync(m => m.DTRId == id);
            if (dTR == null)
            {
                return NotFound();
            }

            return View(dTR);
        }

        // POST: DTR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dTR = await _context.DTR.FindAsync(id);
            _context.DTR.Remove(dTR);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DTRExists(int id)
        {
            return _context.DTR.Any(e => e.DTRId == id);
        }
    }
}
