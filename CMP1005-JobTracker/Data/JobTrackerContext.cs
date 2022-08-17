using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMP1005_JobTracker.Models;

    public class JobTrackerContext : DbContext
    {
    //public readonly object Jobs;

    public JobTrackerContext (DbContextOptions<JobTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Job { get; set; }

        public DbSet<DTR> DTR { get; set; }

        public DbSet<Reminder> Reminder { get; set; }
}
