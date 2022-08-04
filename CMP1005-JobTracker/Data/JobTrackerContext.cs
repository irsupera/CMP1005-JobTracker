using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMP1005_JobTracker.Models;

    public class JobTrackerContext : DbContext
    {
        public JobTrackerContext (DbContextOptions<JobTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<CMP1005_JobTracker.Models.Job> Job { get; set; }
    }
