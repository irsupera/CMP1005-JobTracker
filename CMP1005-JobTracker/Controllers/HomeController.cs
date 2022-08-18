using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMP1005_JobTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CMP1005_JobTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobTrackerContext _context;

        public HomeController(JobTrackerContext context)
        {
            _context = context;
        }

        // GET: Reminder
        public async Task<IActionResult> Index()
        {
            var jobTrackerContext = _context.Reminder.Include(r => r.Jobs);
            return View(await jobTrackerContext.ToListAsync());
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

