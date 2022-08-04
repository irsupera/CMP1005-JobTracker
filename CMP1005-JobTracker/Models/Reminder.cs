using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMP1005_JobTracker.Models
{
    public class Reminder
    {
        [Key]
        public int RemId { get; set; }

        public string Detail { get; set; }

        [DataType(DataType.DateTime)]
        public string DateTime { get; set; }

        [Display(Name = "Job")]
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Jobs { get; set; }

        public Reminder()
        {
        }
    }
}

