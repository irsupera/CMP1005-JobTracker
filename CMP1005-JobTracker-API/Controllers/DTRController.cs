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
    public class DTRController : Controller
    {
        private readonly JobTrackerContext _db;

        public DTRController(JobTrackerContext context)
        {
            _db = context;
        }

        // GET: api/DTR
        [HttpGet]
        public IEnumerable<DTR> Get()
        {
            return _db.DTR.ToList();
            //return new string[] { "value1", "value2" };
        }

        // GET api/DTR/5
        [HttpGet("{id}")]
        public DTR Get(int id)
        {
            return _db.DTR.Where(p => p.DTRId == id).FirstOrDefault();
            //return "value";
        }

        // POST api/DTR
        [HttpPost]
        public StatusCodeResult Post([FromBody] DTR value)
        {
            _db.DTR.Add(value);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/DTR/5
        [HttpPut("{id}")]
        public StatusCodeResult Put(int id, [FromBody] DTR value)
        {
            if (value.DTRId == id)
            {
                _db.DTR.Update(value);
                _db.SaveChanges();
                return Ok();
            }
            return new StatusCodeResult(400);
        }

        // DELETE api/DTR/5
        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            //_db.DTR.Remove(new Job {DTRId == id});
            //_db.SaveChanges();
            return Ok();
        }
    }
}
