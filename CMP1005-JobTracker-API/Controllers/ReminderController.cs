using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMP1005_JobTracker.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CMP1005_JobTracker_API.Controllers
{
    [Route("api/[controller]")]
    public class ReminderController : Controller
    {
        private readonly JobTrackerContext _db;

        public ReminderController(JobTrackerContext context)
        {
            _db = context;
        }

        // GET: api/Reminder
        [HttpGet]
        public IEnumerable<Reminder> Get()
        {
            return _db.Reminder.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/Reminder/5
        [HttpGet("{id}")]
        public Reminder Get(int id)
        {
            return _db.Reminder.Where(p => p.RemId == id).FirstOrDefault();
            //return "value";
        }

        // POST api/Reminder
        [HttpPost]
        public StatusCodeResult Post([FromBody] Reminder value)
        {
            _db.Reminder.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/Reminder/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Reminder value)
        {
            if (value.RemId == id)
            {
                _db.Reminder.Update(value);
                _db.SaveChanges();
                return Ok();
            }
            return new StatusCodeResult(400);
        }

        // DELETE api/Reminder/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            //_db.Reminder.Remove(new Reminder {RemId == id});
            //_db.SaveChanges();
            return Ok();
        }
    }
}
