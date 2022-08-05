using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMP1005_JobTracker.Models
{
    public class DTR
    {
        [Key]
        public int DTRId { get; set; }

        [DataType(DataType.DateTime)]
        public string TimeIn { get; set; }
        [DataType(DataType.DateTime)]
        public string TimeOut { get; set; }

        [Display(Name = "Job")]
        public int JobId { get; set; }

        [ForeignKey("JobId")]
        public virtual Job Jobs { get; set; }

    }
}

