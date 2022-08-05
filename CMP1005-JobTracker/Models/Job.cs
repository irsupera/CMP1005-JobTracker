using System;
using System.ComponentModel.DataAnnotations;

namespace CMP1005_JobTracker.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Company { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }

    }
}

