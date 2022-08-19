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
    public class ReminderController : Controller
    {
        private readonly JobTrackerContext _context;

        public ReminderController(JobTrackerContext context)
        {
            _context = context;
        }

        // GET: Reminder
        public async Task<IActionResult> Index()
        {
            var jobTrackerContext = _context.Reminder.Include(r => r.Jobs);
            return View(await jobTrackerContext.ToListAsync());
        }

        // GET: Reminder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .Include(r => r.Jobs)
                .FirstOrDefaultAsync(m => m.RemId == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // GET: Reminder/Create
        public IActionResult Create()
        {
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company");
            return View();
        }

        // POST: Reminder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RemId,Detail,DateTime,JobId")] Reminder reminder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reminder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", reminder.JobId);
            return View(reminder);
        }

        // GET: Reminder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder.FindAsync(id);
            if (reminder == null)
            {
                return NotFound();
            }
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", reminder.JobId);
            return View(reminder);
        }

        // POST: Reminder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RemId,Detail,DateTime,JobId")] Reminder reminder)
        {
            if (id != reminder.RemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reminder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReminderExists(reminder.RemId))
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
            ViewData["JobId"] = new SelectList(_context.Job, "JobId", "Company", reminder.JobId);
            return View(reminder);
        }

        // GET: Reminder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reminder = await _context.Reminder
                .Include(r => r.Jobs)
                .FirstOrDefaultAsync(m => m.RemId == id);
            if (reminder == null)
            {
                return NotFound();
            }

            return View(reminder);
        }

        // POST: Reminder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reminder = await _context.Reminder.FindAsync(id);
            _context.Reminder.Remove(reminder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReminderExists(int id)
        {
            return _context.Reminder.Any(e => e.RemId == id);
        }
    }
}
