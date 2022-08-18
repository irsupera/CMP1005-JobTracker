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
    public class JobController : Controller
    {
        private readonly JobTrackerContext _db;

        public JobController(JobTrackerContext context)
        {
            _db = context;
        }

        // GET: api/Job
        [HttpGet]
        public IEnumerable<Job> Get()
        {
            return _db.Job.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/Job/5
        [HttpGet("{id}")]
        public Job Get(int id)
        {
            return _db.Job.Where(p => p.JobId == id).FirstOrDefault();
            //return "value";
        }

        // POST api/Job
        [HttpPost]
        public StatusCodeResult Post([FromBody] Job value)
        {
            _db.Job.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/Job/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] Job value)
        {
            if (value.JobId == id)
            {
                _db.Job.Update(value);
                _db.SaveChanges();
                return Ok();
            }
            return new StatusCodeResult(400);
        }

        // DELETE api/Job/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            var job = _db.Job.Where(p => p.JobId == id).FirstOrDefault();
            _db.Job.Remove(job);
            _db.SaveChanges();
            return Ok();

        }
    }
}

