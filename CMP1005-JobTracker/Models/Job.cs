using System;
using System.ComponentModel.DataAnnotations;

namespace CMP1005_JobTracker.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required(ErrorMessage = "Please enter position/designation")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please enter company name")]
        public string Company { get; set; }

        [StringLength(500)]
        public string Detail { get; set; }

        [Required(ErrorMessage = "Please enter application/job status")]
        public string Status { get; set; }

    }
}

